# BeComex

# Instruções de Execução

Esta solução foi construída em .NET 7 utilizando uma arquitetura de 3 camadas:

1. **APP** - Camada de Aplicação
2. **BLL** - Camada de Negócios
3. **DAL** - Camada de Acesso a Dados

Além disso, a camada **DBM (Data Base Manager)** é uma parte adicional que cria um banco de dados SQLite, onde todas as informações são armazenadas.

## Execução

### Passo 1: Data Base Manager (DBM)

1. Primeiro, execute o Data Base Manager.
2. No console que aparecer, selecione a opção 1 (Rollout) para criar o banco de dados, tabelas e inserções iniciais.
3. Se desejar apagar e recriar o banco, selecione a opção 2 e depois a opção 1 novamente.
4. Após a conclusão, você pode prosseguir com a opção 3 e passar para o APP.

### Passo 2: APP

Aqui, o Hangfire está pré-configurado para uso futuro. Dentro do banco de dados, existe uma tabela de log. O Hangfire permite realizar inserções de logs de usuário em segundo plano. Antes de executar, é necessário configurar a connection string do banco de dados SQL Server para criar as tabelas necessárias. Foi escolhido um banco de dados real em vez do SQLite para essa finalidade.

5. Após a configuração, execute a aplicação APP.
6. O Swagger será carregado, e os dois endpoints estarão disponíveis.

### Passo 3: Front-end

Para o front-end, foi utilizado o React com o framework Vite. Siga estas etapas:

7. Execute `npm install` para instalar todas as dependências do projeto.
8. Em seguida, execute `npm run dev` para iniciar o servidor de desenvolvimento do front-end.

Agora, você tem toda a solução em execução!

Certifique-se de que as dependências necessárias estejam instaladas, como o .NET 7 e o Node.js, antes de prosseguir com a execução da solução.

Se surgirem problemas ou dúvidas, não hesite em entrar em contato. Boa sorte!
