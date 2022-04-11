# lower-prices
O presente projeto foi desenvolvido para descobrir através da inserção de uma data e a quantidade de animais de um canil qual é o petshop mais barato para deixar os cães limpos.

## Premissas assumidas

Para tal feito sera considerado o melhor petshop o que oferecer menores preços, em caso de empate o melhor é o mais próximo do canil.

Para desenvolvermos a solução temos as seguintes informações sobre os petshops:

- **Meu Canino Feliz:** Está distante 2km do canil. Em dias de semana o banho para cães pequenos custa R$20,00 e o banho em cães grandes custa R$40,00. Durante os finais  de semana o preço dos banhos é aumentado em 20%.
- **Vai Rex:** Está localizado na mesma avenida do canil, a 1,7km. O preço do banho para dias úteis em cães pequenos é R$15,00 e em cães grandes é R$50,00. Durante os finais 
de semana o preço para cães pequenos é R$ 20,00 e para os grandes é R$ 55,00.
- **ChowChawgas:** Fica a 800m do canil. O preço do banho é o mesmo em todos os dias 
da semana. Para cães pequenos custa R$30 e para cães grandes R$45,00.

Com as informações em mãos assumimos que:
- Cada petshop tera que ser construído de independentemente para possíveis inserções futuras.
- Deve ser ciado um modelo de petshop padrão para ser instanciado.
- Deve haver um controlador para insertação de dados.

## Decisões de projeto

Para melhor resolução do desafio utilizei o diagrama UML abaixo para a separação correta das classes de forma há não haver perdas de informações e acessos indevidos aos atributos.

![Diagramas de Classe UML](https://github.com/GomidesTs/lower-prices/blob/main/Diagramas%20de%20Classe%20UML.png?raw=true)

Para ser considerado um Petshop deve possuir seus atributos da seguinte forma:

Atributos públicos podendo ser acessados para inserção de informações através do controlador principal sendo este o arquivo Program.cs

- public int quantidadeSmall; (Responsável por receber a quantidade de cães pequenos)
- public int quantidadeBig; (Responsável por receber a quantidade de cães grandes)
- public Boolean weekend; (Responsável por receber a data para verificação)

Atributos protegidos que serão acessadores e modificados apenas pelos petshops que está herdado informações da classe principal.
- protected string? name; (Sera modificado para receber o nome dos petshops para analise)
- protected double distance; (Recebera a informação da distância dos petshops em relação ao canil)
- protected double priceSmall; (Recebera a informação do preço da limpeza dos cães pequenos em determinado petshops em relação ao dia da semana)
- protected double priceBig; (Recebera a informação do preço da limpeza dos cães grandes em determinado petshops em relação ao dia da semana)

Atributos privados que serão acessadores somente pela classe Petshop

- private double priceFinal; (Sera responsável por auxiliar ao cálculo do menor preço)

Métodos para cálculos
- public double pricePetshop() (Sendo responsável para retornar ao controlador principal o valor dos preços da lavagem de cada petshop)

Classes com Petshops para analises

Estas clases herdaram as informacoes da classe principal
- class  (Petshop analisado)  : Petshop

Alteraram os atributos para o preço da limpeza de cães pequenos e grandes dependendo da data digitada pelo usuário podendo ser observada no exemplo abaixo
```c#
public void components()
        {
            name = "Petshop";
            distance = R$;
            if (weekend == true)
            {
                priceSmall = R$ * %;
                priceBig = R$ * %;
            }
            else
            {
                priceSmall = R$;
                priceBig = R$;
            }
        }
```
Possuem os métodos de Get para analisamos as informações de Nome e Distância pelo controlador principal
```C#
 public string? GetName()
        {
            return name;
        }

        public double GetDistance()
        {
            return distance;
        }
```
Para o metodo public void components() mostrado a cima funcione corretamente, foi criado o public Boolean isWeekend(DateTime date) que recebe do controlador principal
```c#
public class Date
    {
        public Boolean isWeekend(DateTime date)
        {
            Boolean weekend = false;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                weekend = true;
            }
            return weekend;
        }
    }
```
Para coordenar todo o programa foi criado o controlador Program.cs que esta dividido da seguinte forma.
- Foram criados ArrayList para salvar informações destinadas à comparação do melhor  petshop
```c#
ArrayList name = new ArrayList();
ArrayList price = new ArrayList();
ArrayList distance = new ArrayList();
```
- Instanciamos os objetos para a utilização
```c#
Date weekend = new Date();
MyHappyCanine myHappyCanine = new MyHappyCanine();
GoRex goRex = new GoRex();
ChowChawgas chowChawgas = new ChowChawgas();
```
- Utilizaremos o  Try Catch para  tratar exceções que não temos como prever que irão acontecer ou controlar. 
```c#
 try
    {
        /* code */
    }
    catch (LowerPriceException e)
            {
                Console.WriteLine(e.Message);
            }
```
- O Try Catch  possui uma função public class LowerPriceException que herda as dependências de ApplicationException e sendo esta publica sera utilizada para tratar as exceções em nosso código;
```c#
namespace lower_prices
{
    public class LowerPriceException : ApplicationException
    {
        public LowerPriceException(string mensagem) : base(mensagem)
        {
        }
    }
}
```
- Pedimos ao usuário para inserirmos as informações necessitarias para a captação de dados as tratamos como necessário e as salvamos em variaveis para serem utilizadas.
```c#
System.Console.WriteLine("Informe uma data no formato dd/mm/aaaa");
var date = Console.ReadLine();
DateTime dateUser = Convert.ToDateTime(date);
day = weekend.isWeekend(dateUser);
System.Console.WriteLine("Informe a quantidade de caes pequenos");
small = Convert.ToInt32(Console.ReadLine());
System.Console.WriteLine("Informe a quantidade de caes grandes");
big = Convert.ToInt32(Console.ReadLine());
```
- O exemplo abaixo mostra como é passado os dados capturado para os objetos e retornado para o controlador principal para assim ser possível determinar melhor petshop para levar os cães
```c#
myHappyCanine.quantidadeSmall = small;
myHappyCanine.quantidadeBig = big;
myHappyCanine.weekend = day;
myHappyCanine.components();
name.Add(myHappyCanine.GetName());
distance.Add(myHappyCanine.GetDistance());
price.Add(myHappyCanine.pricePetshop());
```
- Percorremos os ArrayList para determinar qual é o petshop com o menor preço em caso de empate começamos a analisar, qual esta mais próximo obtendo estas informações imprimimos para o usuário nome do melhor petshop e preço total a ser pago pelo Senhor Eduardo
```c#
for (int i = 0; i < name.Count; i++)
     {
         if (Convert.ToDouble(price[i]) < minimum)
            {
                aux = i;
            }
        if (Convert.ToDouble(price[i]) == minimum)
            {
                for (int j = 0; j < distance.Count; j++)
                    {
                        if (Convert.ToDouble(distance[i]) < distanceAux)
                            {
                                aux = j;
                            }
                    }
            }
     }
System.Console.WriteLine($"O menhor petshops e {name[aux]}\nPossuindo o preco total de banho R$ {price[aux]}");
```
## Instruções para executar o sistema
Para executá-lo necessitamos de segui os seguintes passos:
1. Clone o repositório em sua maquina através do comando
```
git clone https://github.com/GomidesTs/lower-prices.git
```
2. Com o clone do repositório realizado navegue ate o diretório do sistema através de seu prompt de comando  e execute o comando
```
dotnet run
```