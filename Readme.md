# EncrLib2
#### .NET Text Encryption Library

EncrLib2 is a simple library for .NET developers. It supports the following encryption/decryption features:

- Simple 
- AES
- TripleDES
- Hash

## Usage

The following examples explains how to use the library.

```sh
using EncrLib2;

private bool VerifyPassword(string pass)
{
    var savedPassword = Encryptor.AESDecrypt(Config.Password);
    return savedPassword == pass;
}
```

For a better security when working with passwords, it is recommended to apply AES or TripleDES to the password and after this, convert the encrypted value to hash.

```sh
using EncrLib2;

private void SavePassword(string pass)
{
    var finalPassword = Encryptor.TripleDESEncrypt(pass);
    Config.StorePass(Encryptor.ToHash(finalPassword));
}
```

## Development

Would you like to contribute? Feel free to download the source code.

## License
MIT License

Copyright (c) 2023 Exe Innovate

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.