# GradeRank-API

## Descrição

GradeRank-API é uma API para avaliar disciplinas optativas cursadas pelos estudantes. O projeto utiliza a arquitetura hexagonal para promover a separação de preocupações e modularidade do sistema.

## Arquitetura Hexagonal

A arquitetura hexagonal é uma abordagem que visa separar as preocupações e promover a flexibilidade e testabilidade do sistema. No projeto GradeRank-API, a arquitetura hexagonal é implementada da seguinte maneira:

### Núcleo do Domínio

O núcleo do domínio é o componente central do sistema, contendo a lógica de negócios e regras para o cálculo e classificação das notas dos estudantes. Ele não depende de nenhum componente externo e define as interfaces (portas) para interagir com as camadas externas.

### Portas

As portas definem os contratos de comunicação entre o núcleo do domínio e as camadas externas. No projeto GradeRank-API, temos as seguintes portas:

- `ICourseService`: Define os métodos para acessar e manipular os dados das diciplinas.
- `IEvaluationService`: Define os métodos manipular e acessar os dados das avaliações.
- `IProfessorService`: Define os métodos para acessar e manipular os dados de professores.
- `IQuestionService`: Define os métodos para acessar e manipular os dados do questionário.
- `IUserService`: Define os métodos para acessar e manipular os dados dos usuários.

- `ICourseRepository`: Define os métodos para acessar e manipular os dados das diciplinas no banco de dados.
- `IEvaluationRepository`: Define os métodos para acessar e manipular as avaliações no banco de dados.
- `IProfessorRepository`: Define os métodos para acessar e manipular os dados de professores no banco de dados.
- `IQuestionRepository`: Define os métodos para acessar os dados do questionário no banco de dados.
- `IUserRepository`: Define os métodos para acessar e manipular os dados de usuário no banco de dados.

### Adaptadores

Os adaptadores são as implementações concretas das portas. Eles conectam as portas do núcleo do domínio com as camadas externas. No projeto GradeRank-API, temos os seguintes adaptadores:

- `CourseController`: Lida com as operações de entrada e saída de dados relacionadas ao curso. 
- `EvaluationController`: Lida com as operações de entrada e saída de dados relacionadas às avaliações.
- `ProfessorController`: Lida com as operações de entrada e saída de dados relacionadas aos professores.
- `QuestionController`: Lida com as operações de entrada e saída de dados relacionadas ao questionário.
- `UserController`: Lida com as operações de entrada e saída de dados relacionadas aos usuários.


- `CourseRepository`: Implementa os métodos da `ICourseRepository` utilizando um banco de dados SQLServer.
- `EvaluationRepository`: Implementa os métodos da `IEvaluationRepository` utilizando um banco de dados SQLServer.
- `HealthStatusRepository`: Implementa os métodos da `IHealthStatusRepository` utilizando um banco de dados SQLServer.
- `ProfessorRepository`: Implementa os métodos da `IProfessorRepository` utilizando um banco de dados SQLServer.
- `QuestionRepository`: Implementa os métodos da `IQuestionRepository` utilizando um banco de dados SQLServer.
- `UserRepository`: Implementa os métodos da `IUserRepository` utilizando um banco de dados SQLServer.

![image](https://github.com/ailtonvjunior/GradeRank-API/assets/37911189/d03d834c-46ce-40f1-b19a-ac7eb745c580)

## Configuração e Execução

### Pré-requisitos

- .Net 6.0

### Instalação

1. Clone o repositório:

   ```shell
   git clone https://github.com/ailtonvjunior/GradeRank-API.git
