# Desafio Lets Code

- O projeto de API segue o Mediator Pattern com CQRS (Command Query Responsibility Segregation). Sendo assim, toda lógica fica nos Handlers localizados no projeto Core, as Controllers apenas repassam informação para o Core do sistema;
- As validações são feitas utilizando a biblioteca FluentValidation. É adicionado um PipelineBehavior ao Mediator para as validações e um Middleware retorna o JSON com os erros;
- Todas as implementações de Handlers e Validators são adicionadas por Injeção de dependência utilizando Assembly Scanning;
- É utilizado AutoMapper para mapear os dados vindos dos Commands para Models do sistema.
