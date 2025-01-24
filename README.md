# BRDocs

**BRDocs** � um projeto open-source destinado a realizar a valida��o de documentos comumente utilizados em aplica��es brasileiras, como CPF e CNPJ. 
A ideia � fornecer uma maneira simples e eficiente de validar esses documentos diretamente no seu c�digo.

## Funcionalidades

- Valida��o de CPF.

_Outras valida��es ser�o adicionados no futuro._

## Instala��o

### Usando o Git

1. Clone o reposit�rio:
```bash
git clone https://github.com/username/BRDocs.git
cd BRDocs
```

2. Abra o projeto no Visual Studio ou na sua IDE de prefer�ncia.

3. Restaure as depend�ncias:
```bash
dotnet restore
```

4. Para rodar o projeto, use o comando:
```bash
dotnet run
```

## Como usar

### Exemplo em C#:

```csharp
using BRDocs;

class Program
{
    static void Main()
    {
        // Validando CPF
        bool cpfValido = CPF.Validar("123.456.789-09");
        Console.WriteLine($"CPF V�lido? {cpfValido}");

        // Validando CNPJ
        bool cnpjValido = CNPJ.Validar("12.345.678/0001-90");
        Console.WriteLine($"CNPJ V�lido? {cnpjValido}");
    }
}
```

## Contribuindo
Sinta-se � vontade para contribuir com o projeto! Se voc� encontrar um bug, tiver uma sugest�o de melhoria ou quiser adicionar suporte para mais tipos de documentos, fique � vontade para abrir uma issue ou fazer um pull request.

Para come�ar a contribuir, siga os passos abaixo:

1. Fork este reposit�rio.
2. Crie uma branch para a sua feature (git checkout -b feat/minha-nova-feature).
3. Fa�a suas altera��es e commite (git commit -am 'Adicionando nova valida��o').
4. Envie para o reposit�rio remoto (git push origin minha-nova-feature).
5. Abra um pull request.

## Licen�a
Este projeto est� licenciado sob a [MIT License](https://mit-license.org/).