# ReadMe - Projeto de Cálculo de Seguro de Veículos

## 1. Ambiente de Execução

### 1.1. Ambiente de Execução Desejável

Para executar este projeto, você pode usar o seguinte ambiente:

- **IDE**: Visual Studio (Use a versão que você tem disponível) ou VS Code.
- **Banco de Dados**: Use seu banco de dados Relacional de Preferência.
- **Modelo de Hospedagem/Deploy**: Escolha um dos seguintes:

    - Serviço de hospedagem em nuvem, como Azure App Service.
    - Servidores web tradicionais, como IIS ou Self Host.
    - Containers.

## 2. Questões Práticas

### 2.1. Descrição do Exame

Este projeto consiste na construção de um serviço que realiza o cálculo de seguro de veículos com base nas seguintes variáveis:

- Valor do Veículo
- Taxa de Risco
- Prêmio de Risco
- Prêmio Puro
- Prêmio Comercial

O cálculo é feito da seguinte forma:

#### Cálculo:

- Variável Estática 1: MARGEM_SEGURANÇA = 3%
- Variável Estática 2: LUCRO = 5%

**Taxa de Risco** = (Valor do Veículo * 5) / (2 x Valor do Veículo)

**Prêmio de Risco** = Taxa de Risco * Valor do Veículo

**Prêmio Puro** = Prêmio de Risco * (1 + MARGEM_SEGURANÇA)

**Prêmio Comercial** = LUCRO * Prêmio Puro

**Exemplo:**

Valor do Veículo = R$ 10.000,00

Taxa de Risco = 50.000 / (2 x 10.000) = 2,5 %

Prêmio de Risco = 2,5% x 10.000 = R$ 250,00

Prêmio Puro = 250 x (1 + 0,03) = R$ 257,50

Prêmio Comercial = 5% x 257,50 = R$ 270,37

Valor do Seguro é R$ 270,37

**Observação**: Este cálculo é hipotético e didático.

#### Funcionalidades da API:

- Gravar os dados de um Seguro em banco de dados relacional. Um seguro possui um Veículo {Valor do Veículo, Marca/Modelo Veículo} e um Segurado {Nome, CPF, idade}.
- Calcular o Valor do Seguro de Veículos.
- Pesquisar os dados de um Seguro.
- Gerar um relatório com as médias aritméticas dos Seguros. A saída desse relatório deve ser em JSON.

### 2.2. Requisitos não-funcionais

Para o desenvolvimento deste projeto, são necessários os seguintes requisitos não-funcionais:

- Uso de tecnologia .NET Core para Construção da API.
- Organização do domínio com uso de arquitetura limpa (Clean Architecture).
- Testes de unidade automatizados do cálculo do seguro.

### 2.3. Recursos de apoio

- [Clean Architecture em .NET](https://github.com/ivanpaulovich/clean-architecture-manga)

## 3. Critérios de Avaliação

Os critérios de avaliação para este projeto incluem:

- Código Limpo.
- Automação de testes de unidade.

---
Este documento fornece uma visão geral do projeto de cálculo de seguro de veículos, incluindo os requisitos, o ambiente de execução e os critérios de avaliação. Para obter mais detalhes sobre a implementação, consulte o código-fonte no repositório Git.
