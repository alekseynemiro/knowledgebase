---
title: "Python: Стандарты"
description: Стандарты кодирования Python.
tags:
  - Python
  - Guide
  - Code style
  - Стандарты кодирования
---

# Python: Стандарты

В примере ниже показаны основы форматирования кода в Python.

* [x] Для имен файлов и папок используйте строчные буквы и символ подчеркивания для разделения слов.

```python hello_world.py
class UsePascalCaseName:
    """Class description here."""

    # [x] use 4 spaces for indentation
    # [x] use lowercase and underscores for member names

    USE_UPPER_CASE_FOR_CONSTANTS = "constant value"

    def __init__(self, number: float, text: str):
        """__init__ is special magic method - class constructor.

        Args:
            number (float): Description for 'number' argument.
            text (str): Description for 'text' argument.
        """
        self.number = number  # public member
        self.text = text      # public member
        self.__value = 0.0    # private member

    def public_method(self, value: float):
        """Use `self` for the first argument to instance methods.

        Args:
            value (float):  Description for 'value' argument.
        """
        self.__value = value

    def _protected_method(self):
        """Python does not have protected members,
        but there is a convention that protected methods should start with an underscore.
        """
        pass

    def __private_method(self):
        """Python does not have private members,
        but there is a convention that private methods should start with a double underscore.
        """
        pass

    @classmethod
    def class_method(cls):
        """Always use cls for the first argument to class methods."""
        return cls.USE_UPPER_CASE_FOR_CONSTANTS

# create instance
instance = UsePascalCaseName() # use spaces between variable name and type

# invoke public method and pass the 'value' argument
instance.public_method(value=1.0) # do not use spaces between the argument name and the value
```
