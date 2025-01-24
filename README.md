# BRDocs

**BRDocs** é um projeto open-source destinado a realizar a validação de documentos comumente utilizados em aplicações brasileiras, como CPF e CNPJ. 
A ideia é fornecer uma maneira simples e eficiente de validar esses documentos diretamente no seu código.

## Funcionalidades

- Validação de CPF.

_Outras validações serão adicionados no futuro._

## Instalação

### Usando o Git

1. Clone o repositório:
```bash
git clone https://github.com/username/BRDocs.git
cd BRDocs
```

2. Abra o projeto no Visual Studio ou na sua IDE de preferência.

3. Restaure as dependências:
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
        Console.WriteLine($"CPF Válido? {cpfValido}");

        // Validando CNPJ
        bool cnpjValido = CNPJ.Validar("12.345.678/0001-90");
        Console.WriteLine($"CNPJ Válido? {cnpjValido}");
    }
}
```

## Contribuindo
Sinta-se à vontade para contribuir com o projeto! Se você encontrar um bug, tiver uma sugestão de melhoria ou quiser adicionar suporte para mais tipos de documentos, fique à vontade para abrir uma issue ou fazer um pull request.

Para começar a contribuir, siga os passos abaixo:

1. Fork este repositório.
2. Crie uma branch para a sua feature (git checkout -b feat/minha-nova-feature).
3. Faça suas alterações e commite (git commit -am 'Adicionando nova validação').
4. Envie para o repositório remoto (git push origin minha-nova-feature).
5. Abra um pull request.

## Licença
Este projeto está licenciado sob a [MIT License](https://mit-license.org/).