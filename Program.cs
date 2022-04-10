using System.Collections;
using lower_prices;

namespace LowerpricePetshops
{
    class Program
    {
        static void Main(string[] args)
        {
            int small;
            int big;
            Double minimum;
            Double distanceAux;
            int aux = 0;
            Boolean day;
            ArrayList name = new ArrayList();
            ArrayList price = new ArrayList();
            ArrayList distance = new ArrayList();
            Date weekend = new Date();
            MyHappyCanine myHappyCanine = new MyHappyCanine();
            GoRex goRex = new GoRex();
            ChowChawgas chowChawgas = new ChowChawgas();

            try
            {
                System.Console.WriteLine("Informe uma data no formato dd/mm/aaaa");
                var date = Console.ReadLine();
                DateTime dateUser = Convert.ToDateTime(date);
                day = weekend.isWeekend(dateUser);
                System.Console.WriteLine("Informe a quantidade de caes pequenos");
                small = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Informe a quantidade de caes grandes");
                big = Convert.ToInt32(Console.ReadLine());

                myHappyCanine.quantidadeSmall = small;
                myHappyCanine.quantidadeBig = big;
                myHappyCanine.weekend = day;
                myHappyCanine.components();
                name.Add(myHappyCanine.GetName());
                distance.Add(myHappyCanine.GetDistance());
                price.Add(myHappyCanine.pricePetshop());

                goRex.quantidadeSmall = small;
                goRex.quantidadeBig = big;
                goRex.weekend = day;
                goRex.components();
                name.Add(goRex.GetName());
                distance.Add(goRex.GetDistance());
                price.Add(goRex.pricePetshop());

                chowChawgas.quantidadeSmall = small;
                chowChawgas.quantidadeBig = big;
                chowChawgas.components();
                name.Add(chowChawgas.GetName());
                distance.Add(chowChawgas.GetDistance());
                price.Add(chowChawgas.pricePetshop());

                minimum = Convert.ToDouble(price[0]);
                distanceAux = Convert.ToDouble(distance[0]);
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
            }
            catch (LowerPriceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}