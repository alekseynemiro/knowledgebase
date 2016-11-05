using System;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

// Simple example of xml serialization/deserialization

// Простой пример xml сериализации/десериализации
// Ветка: http://kbyte.ru/ru/Forums/Show.aspx?id=17081

namespace XmlSerialization
{

	class Program
	{

		static void Main(string[] args)
		{
      // read xml
			// читаем xml
      var xml = XmlReader.Create("file.xml");

      while (xml.Read())
      {
        if (xml.NodeType == XmlNodeType.Element)
        {
          if (xml.Name == "Request")
          {
            var request = LoadXml<Request>(xml.ReadOuterXml());
            Console.WriteLine(request.Id);
            Console.WriteLine(request.Name);
            Console.WriteLine(request.Company);
            Console.WriteLine();
            var sss = GetXml(request);
          }
        }
      }

      Console.WriteLine("Press any key to exit...");
			// Console.WriteLine("Потрогайте любую клавишу для выхода...");
			Console.ReadKey();
		}

		/// <summary>
		/// Returns XML.
		/// </summary>
		static string GetXml(object source)
		{
			using (var ms = new MemoryStream())
			{
				using (var x = new XmlTextWriter(ms, Encoding.UTF8))
				{
					x.Formatting = Formatting.Indented;
					var mySerializer = new XmlSerializer(source.GetType());
          var xns = new XmlSerializerNamespaces();
          xns.Add(String.Empty, String.Empty);
          mySerializer.Serialize(x, source, xns);
				}
				return Encoding.UTF8.GetString(ms.ToArray());
			}
		}

		/// <summary>
    /// <para>Returns object from XML.</para>
    /// <para lang="ru">Загружает данные из XML и возвращает экземпляр объекта указанного типа.</para>
		/// </summary>
		static T LoadXml<T>(string source)
		{
			var mySerializer = new XmlSerializer(typeof(T));
			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(source)))
			{
				return (T)mySerializer.Deserialize(ms);
			}
		}

	}
}
