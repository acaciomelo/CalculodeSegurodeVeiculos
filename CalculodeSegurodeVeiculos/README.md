# ReadMe - Projeto de C�lculo de Seguro de Ve�culos

## 1. Ambiente de Execu��o

### 1.1. Ambiente de Execu��o Desej�vel

Para executar este projeto, voc� pode usar o seguinte ambiente:

- **IDE**: Visual Studio (Use a vers�o que voc� tem dispon�vel) ou VS Code.
- **Banco de Dados**: Use seu banco de dados Relacional de Prefer�ncia.
- **Modelo de Hospedagem/Deploy**: Escolha um dos seguintes:

    - Servi�o de hospedagem em nuvem, como Azure App Service.
    - Servidores web tradicionais, como IIS ou Self Host.
    - Containers.

## 2. Quest�es Pr�ticas

### 2.1. Descri��o do Exame

Este projeto consiste na constru��o de um servi�o que realiza o c�lculo de seguro de ve�culos com base nas seguintes vari�veis:

- Valor do Ve�culo
- Taxa de Risco
- Pr�mio de Risco
- Pr�mio Puro
- Pr�mio Comercial

O c�lculo � feito da seguinte forma:

#### C�lculo:

- Vari�vel Est�tica 1: MARGEM_SEGURAN�A = 3%
- Vari�vel Est�tica 2: LUCRO = 5%

**Taxa de Risco** = (Valor do Ve�culo * 5) / (2 x Valor do Ve�culo)

**Pr�mio de Risco** = Taxa de Risco * Valor do Ve�culo

**Pr�mio Puro** = Pr�mio de Risco * (1 + MARGEM_SEGURAN�A)

**Pr�mio Comercial** = LUCRO * Pr�mio Puro

**Exemplo:**

Valor do Ve�culo = R$ 10.000,00

Taxa de Risco = 50.000 / (2 x 10.000) = 2,5 %

Pr�mio de Risco = 2,5% x 10.000 = R$ 250,00

Pr�mio Puro = 250 x (1 + 0,03) = R$ 257,50

Pr�mio Comercial = 5% x 257,50 = R$ 270,37

Valor do Seguro � R$ 270,37

**Observa��o**: Este c�lculo � hipot�tico e did�tico.

#### Funcionalidades da API:

- Gravar os dados de um Seguro em banco de dados relacional. Um seguro possui um Ve�culo {Valor do Ve�culo, Marca/Modelo Ve�culo} e um Segurado {Nome, CPF, idade}.
- Calcular o Valor do Seguro de Ve�culos.
- Pesquisar os dados de um Seguro.
- Gerar um relat�rio com as m�dias aritm�ticas dos Seguros. A sa�da desse relat�rio deve ser em JSON.

### 2.2. Requisitos n�o-funcionais

Para o desenvolvimento deste projeto, s�o necess�rios os seguintes requisitos n�o-funcionais:

- Uso de tecnologia .NET Core para Constru��o da API.
- Organiza��o do dom�nio com uso de arquitetura limpa (Clean Architecture).
- Testes de unidade automatizados do c�lculo do seguro.

### 2.3. Recursos de apoio

- [Clean Architecture em .NET](https://github.com/ivanpaulovich/clean-architecture-manga)

## 3. Crit�rios de Avalia��o

Os crit�rios de avalia��o para este projeto incluem:

- C�digo Limpo.
- Automa��o de testes de unidade.

---
Este documento fornece uma vis�o geral do projeto de c�lculo de seguro de ve�culos, incluindo os requisitos, o ambiente de execu��o e os crit�rios de avalia��o. Para obter mais detalhes sobre a implementa��o, consulte o c�digo-fonte no reposit�rio Git.
