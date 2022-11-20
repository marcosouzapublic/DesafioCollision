# Desafio Collision

Projeto criado para atender ao enunciado enviado pela Collision.

# Arquitetura do Projeto

O projeto foi desenvolvido utilizando padrões da Arquitetura Limpa, com camadas bem definidas entre **Domínio, Infra e Aplicação**, onde camadas de mais alto nível não acessam camadas de mais baixo nível.

# Como rodar o projeto

- Aplicação:

A camada executável do projeto é a camada de aplicação, cujo a qual contém um projeto do tipo Web Application API.
O projeto está configurado para ser rodado no **Docker**.

- Banco de dados:

O banco de dados utilizado é o SQL Server, também adicionado ao **Docker**. Necessário baixar a imagem do mesmo através do seguinte comando:

docker run -it `
    -e "ACCEPT_EULA=Y" `
    -e "SA_PASSWORD=A&VeryComplex123Password" `
    -p 1433:1433 `
    --name sql-server-2022 `
    mcr.microsoft.com/mssql/server:2022-latest
    
Os parâmetros de execução do banco de dados poderão ser alterados, tanto nesse momento de download da imagem para o docker, quanto no arquivo de configuração da API, dentro da connection string _SqlServerDb_.

# AppSettings

Dentro do arquivo de configuração appSettings.Json, localizado na raíz do projeto da API, é necessário alterar o IP para o IP da máquina onde irá rodar a instância do SQL Server, conforme imagem abaixo:

![image](https://user-images.githubusercontent.com/9392695/202921052-598d98d4-8015-440d-93a1-dfd8bec3487c.png)

Obs.: Tanta na bibliografia básica quanto em alguns testes, é possível notar a palavra _localhost_ ao invés do endereço de IP, porém, na minha experiência percebo que o endereço funciona 100% das vezes, diferente do localhost.

A princípio, todas as demais configurações já estarão ok, podendo ser alteradas no mesmo arquivo, se necessário.

# Code First
O projeto está configurado no padrão **code first**, utilizando o framework **Entity Framework Core**. 
Automaticamente o banco de dados será criado na primeira execução do projeto, tal qual suas tabelas e estruturas.

# Swagger e os Endpoints
Os endpoints do projeto poderão ser acessados através do Swagger, utilizando a seguinte URL: endereco-local:porta-local/swagger/index.html.
Toda documentação envolvendo os parâmetros, tipos de retorno e errors estão sendo tratadas diretamente no swagger.

![image](https://user-images.githubusercontent.com/9392695/202921326-8b02ef38-de51-4fe5-8dbb-d54d8a1c499e.png)


# Tratativa de Exceções
Além das tratativas específicas para as requisições, **um middleware central** também foi incluído para a tratativa de exceções. As mesmas são retornadas na própria interface do swagger. Caso deseje, é possível provocar uma exception, parando o serviço do SQL Server e tentando utilizar um dos endpoints listados.
