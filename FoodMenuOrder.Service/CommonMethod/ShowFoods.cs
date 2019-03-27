using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuOrder.Service.CommonMethod
{
    public class ShowFoods
    {
        public void Show()
        {
            Console.WriteLine("八大菜系");
        }
    }

    public class ShowFish
    {
        public void ShowSlicedFishInHot()
        {
            Console.WriteLine("[川菜]-水煮鱼-辣");
        }

        public void ShowSweetAndSourFish()
        {
            Console.WriteLine("[鲁菜]-糖醋鱼-酸甜");
        }
        public void ShowSteamedFish()
        {
            Console.WriteLine("[粤菜]-清蒸鱼-鲜");
        }
    }

    public class ShowPig
    {
        public void ShowHotPig()
        {
            Console.WriteLine("烤猪");
        }

        public void ShowFiretPig()
        {
            Console.WriteLine("烧猪");
        }
    }

    public class ShowChicken
    {
        public void ShowFireChicken()
        {
            Console.WriteLine("烧鸡");
        }

        public void ShowSteamedPig()
        {
            Console.WriteLine("白切鸡");
        }
    }
}
