using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scent.CO
{
    public class Product
    {
        public String ImagePath { get; set; }
        public String Name { get; set; }
        public int Volume { get; set; }
        public String Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public List<int> VolumeVariant { get; set; }
        public List<float> PriceVariant { get; set; }
        public String DescribeVolumeVariant
        {
            get {
                String volumeVariantDescription = "Available Variant: ";
                for (int i = 0; i < VolumeVariant.Count; i++)
                {
                    volumeVariantDescription += VolumeVariant[i].ToString() + " mL ";
                    if (i != VolumeVariant.Count - 1)
                    {
                        volumeVariantDescription += " | ";
                    }
                }
                return volumeVariantDescription;
            }
        }
        public String DescribePriceVariant
        {
            get
            {
                String priceVariantDescription = "Price: ";
                for (int i = 0; i < PriceVariant.Count; i++)
                {
                    priceVariantDescription += "RM" + PriceVariant[i].ToString();
                    if (i != VolumeVariant.Count - 1)
                    {
                        priceVariantDescription += " | ";
                    }
                }
                return priceVariantDescription;
            }
        }


        public Product(string imagePath, string name, int volume, string description, float price, int quantity)
        {
            ImagePath = imagePath;
            Name = name;
            Volume = volume;
            Description = description;
            Price = price;
            Quantity = quantity;
            VolumeVariant = new List<int>();
            PriceVariant = new List<float>();
        }

        public void addVariant(int volume, float price)
        {
            VolumeVariant.Add(volume);
            PriceVariant.Add(price);
        }
    }

}