# Desafio de Login no ECAC

Este projeto tem como objetivo realizar o login no sistema e-CAC (Centro Virtual de Atendimento ao Contribuinte) da Receita Federal utilizando o certificado digital do tipo A1. O login é feito por meio de um certificado digital (arquivo PFX) e a respectiva senha do usuário.

## Ferramentas Utilizadas
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

## Índice

- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Execução](#execução)
- [Funcionamento do Programa](#funcionamento-do-programa)
- [Exemplo de Execução](#exemplo-de-execução)
- [Estrutura do Código](#estrutura-do-código)
- [Possíveis Erros e Soluções](#possíveis-erros-e-soluções)
- [Contribuindo](#contribuindo)
- [Licença](#licença)

## Pré-requisitos

Antes de executar o projeto, certifique-se de que possui os seguintes itens:

- **.NET 6 ou superior** instalado. Você pode verificar a versão instalada com o seguinte comando:
  
  ```bash
  dotnet --version

## Instalação

Para instalar e rodar o projeto localmente, siga os passos abaixo:

- **Clonar Repositório pelo Visual Studio 2022** 
- **Limpar Solução**
- **Compilar Solução**

## Execução
Agora, para rodar o projeto, utilize o seguinte comando: Ctrl + F5 ou executar direto no Bash dotnet run

## Funcionamento do Programa 
O programa realiza os seguintes passos:

- **Obter o Certificado:** O programa solicita o caminho do arquivo PFX (certificado digital A1) e verifica se o caminho fornecido é válido.
- **Obter a Senha do Certificado:** O programa solicita a senha do certificado, sendo que a senha é lida de forma segura (não será exibida na tela).
- **Autenticação:** O certificado e a senha são enviados para o sistema ECAC da Receita Federal em uma requisição HTTP, para realizar o login.
- **Resultado:** O programa exibe no console se o login foi realizado com sucesso ou falhou, com base na resposta do sistema.

## Exemplo de Execução

Após rodar o projeto, o programa exibirá os seguintes prompts:

```
Seja bem-vindo ao Desafio de Login do ECAC.
Estarei utilizando a opção de login via Certificado A1.
Por favor, insira o caminho do arquivo do certificado:
C:\certificados\meucertificado.pfx
Por favor, insira a senha do certificado:
********
Login realizado com sucesso!

```

ou no caso de algum erro

```
Seja bem-vindo ao Desafio de Login do ECAC.
Estarei utilizando a opção de login via Certificado A1.
Por favor, insira o caminho do arquivo do certificado:
C:\certificados\meucertificado.pfx
Por favor, insira a senha do certificado:
********
Falha ao realizar login.

```

## Estrutura do Código

O código está dividido em métodos para facilitar a leitura e manutenção:

- **ObterCaminhoCertificado():** Método que solicita ao usuário o caminho do arquivo do certificado e valida se o caminho existe.
- **ObterSenhaCertificado():** Método que solicita ao usuário a senha do certificado e a lê de forma segura, sem exibir a senha no console.
- **EnviarCertificado():** Método que envia o arquivo do certificado e a senha para o ECAC, utilizando a classe HttpClient para fazer a requisição POST.

## Possíveis Erros e Soluções

```
1. Erro: "Caminho do certificado inválido"
Solução: Certifique-se de que o caminho do arquivo do certificado está correto e que o arquivo existe.
2. Erro: "Falha ao realizar login"
Solução: Verifique se o certificado está no formato correto (PFX) e se a senha informada está correta.
3. Erro: "Não foi possível carregar o certificado"
Solução: Verifique se o certificado foi importado corretamente e se a senha está correta.
4. Erro: "Acesso negado ao arquivo do certificado"
```

## Contribuindo

Se você quiser contribuir com o projeto, siga os seguintes passos:

- **Faça um fork deste repositório.**
- **Crie uma branch para a sua modificação:**

```
git checkout -b minha-modificacao

```

- **Faça as alterações necessárias.**
- **Envie um pull request com a descrição das mudanças feitas.**

## Licença
Este projeto está licenciado sob a **MIT License**.

