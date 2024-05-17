# Gerenciamento de Registros
Foi proposto na matéria de Banco de Dados NoSQL, fazer uma interface que fizesse o CRUD(Create, Read, Update e Delete) no banco de dados <b>MongoDB</b>. 

## Tecnologias usadas:
 - Linguagem de programação CSharp usando o Windows Forms.
 - Banco de Dados MongoDB.

## O que foi feito:

Button Adcionar (Create):
  - Formulário para inserir novos registros.
  - Campos: ID, Nome, Email, Data_Nasc e Telefone.
  - Botão para confirmar o cadastro e adicionar o registro ao MongoDB.
  
Button Consulta (Read):
  - Lista para exibir todos os registros cadastrados.
  - Funcionalidade para selecionar um registro e exibir detalhes (ID, Nome,  Email, Data_Nasc, Telefone).
    
Button Alterar (Update):
  - Funcionalidade para editar um registro selecionado.
  - Formulário preenchido com os dados atuais do registro.
  - Botão para confirmar a atualização e salvar as alterações no MongoDB.
    
Button Exclusão (Delete):
  - Funcionalidade para excluir um registro selecionado.
  - Confirmação antes de excluir o registro do MongoDB.

# Instruções para uso
 - [`codigo`](codigo)
 - [`executavel`](executavel)
   - [Gerenciador-de-Registros.exe](executavel/Gerenciador-de-Registros.exe)
   - [README.md](executavel/README.md)
 - [.gitattributes](.gitattributes)
 - [.gitgnore](.gitgnore)
 - [Gerenciamento-de-registros.sln](Gerenciamento-de-registros.sln)
 - [README.md](README.md) 

A pasta [`codigo`](codigo) é onde está armazenado todo o código fonte do projeto.

A pasta [`executavel`](executavel) é onde está armazenado o executável [Gerenciador-de-Registros.exe](executavel/Gerenciador-de-Registros.exe) e o [README.md](executavel/README.md) que explica como usar e o que é preciso para executável funcionar. 

O arquivo [.gitattributes](.gitattributes) é usado para associar atributos específicos a arquivos e diretórios em um repositório Git. Esses atributos podem controlar o comportamento do Git durante operações como comparação de arquivos, mesclagem de branches e outras operações relacionadas ao controle de versão.

O arquivo [.gitgnore](.gitgnore) é usado para especificar arquivos e diretórios que o Git deve ignorar ao rastrear as alterações em um repositório. Por exemplo, você pode querer ignorar arquivos de log, arquivos temporários, diretórios de compilação ou quaisquer outros arquivos que não sejam necessários para o controle de versão do seu projeto. Isso é útil para evitar poluir o histórico do Git com arquivos desnecessários e para garantir que apenas os arquivos relevantes sejam versionados.

O arquivo [Gerenciamento-de-registros.sln](Gerenciamento-de-registros.sln) é responsável pelo gerenciamento e a organização de projetos relacionados em uma solução dentro do Visual Studio. Ele fornece uma maneira conveniente de trabalhar com vários projetos em um único ambiente de desenvolvimento e facilita o processo de build, depuração e manutenção de software.

O [README.md](README.md) é onde está as informações do projeto.
