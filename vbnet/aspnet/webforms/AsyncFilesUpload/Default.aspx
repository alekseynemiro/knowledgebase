<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AsyncFilesUpload._Default" %>
<!DOCTYPE html>
<html>
  <head runat="server">
    <title></title>
    <script src="/Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
  </head>
  <body>
    <form id="form1" runat="server">
      <input type="file" name="files" id="files" multiple="true" />
      <br />
      <!--input type="button" value="Submit" onclick="UploadFiles($('#files').prop('files'));" /-->
      <hr />
      <div id="status"></div>

      <script type="text/javascript">
        $(document).ready(function(){          if(window.FileReader == null) 
          {
          	alert("Unfortunately, your browser does not support HTML5.");
            // alert("К сожалению, ваш браузер не поддерживает HTML5 или функции загрузки файлов. Пожалуйста, убедитесь, что вы используете последнюю версию браузера, либо воспользуйтесь другим браузером, поддерживающим HTML5: Chrome, Safari, FireFox, Opera, IE10/11.");
            return;
          }

					// add file change handler
          // целяем обработчик события, который будет срабатывать сразу при выборе файлов
          $("#files").bind({ change: function () { UploadFiles(this.files); } });
        });

				// function for uploading files
        // функция отправки файлов на сервер
        function UploadFiles(files) {
					// clear status info
          // очищаем блок вывода статуса
        	$('#status').empty();

        	// processing each of the selected files
          // перебираем выбранные файлы
        	$.each(files, function (i, file) {
						// add status info
            // добавляем файл в блок статуса
            // процен загрузки будет отображаться в span
        		var fileStatus = $('<div>File: <strong>' + file.name + '</strong> <span class="progress">0%</span></div>').appendTo('#status');

						// create file reader
            // создаем читатель файлов
        		var reader = new FileReader();

        		// bind handler complete the file upload
            // привязываем обработчик завершения отправки файла
        		reader.onload = (function () {
							// create form data
              // создаем форму, которая будет отправлена на сервер (т.к. файл нужно отправлять методом POST)
        			var data = new FormData();

							// add file to form
              // передаем в параметр file, файл, который нужно отправить на сервер (file - это переменная из цикла, см. 35 строку)
        			data.append("file", file);

							// send file to server
              // метод отправки файла при помощи jQuery
              $.ajax({
              	url: "/Upload.aspx",            // page that expects a file in the parameter <file> // страница, которая будет принимать файл в параметре file
                enctype: "multipart/form-data", // important to specify the type of content // важно правильно указать тип содержимого
                type: "POST",                   // files are sent only by the POST method // файлы отправляются только методом POST
                xhr: function () {
                  var myXhr = $.ajaxSettings.xhr();
                  if (myXhr.upload) {
                  	// bind handler send the data
                    // добавляем обработчик отправки данных
                    myXhr.upload.addEventListener("progress", function (e) {
                    	if (e.lengthComputable) {
												// change status info
                        // меняем в статусе информацию о состоянии отправки файла на сервер
                        $('.progress', fileStatus).html(Math.round((e.loaded * 100) / e.total) + '%');
                      }
                    }, false);
                  }
                  return myXhr;
                },
                beforeSend: function () {
                	// alert("Sending..."); 
                  // здесь можно написать код, который будет вызываться перед отправкой файла на сервер
                  // alert("Отправка файла..."); 
                },
                success: function (result) {
                	alert(file.name + ' done: ' + result);
                  // код обработки результата загрузки файла
                  // alert(file.name + ' обработан: ' + result);
                },
                error: function (e, status, message) {
                	alert("Error: HTTP " + status + " / " + message + ".");
                  // alert("К сожалению, при загрузке файла произошла ошибка: HTTP " + status + " / " + message + ".");
                },
                data: data,         // form data // данные формы
                cache: false,       // кэширование нужно отключить
                contentType: false, // чтобы не было проблем с multipart/form-data
                processData: false
              });
            });

						// run!
            // запуск процедуры отправки файла на сервер
            reader.readAsArrayBuffer(file);
          });
        }
      </script>
    </form>
  </body>
</html>
