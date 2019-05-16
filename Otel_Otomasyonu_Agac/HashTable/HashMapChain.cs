using Otel_Otomasyonu_Agac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashUygulama
{
    public class HashMapChain
    {
        int Iller = 4;
        int Ilceler = 6;
        LinkedHashEntry[,] table;
        public HashMapChain()
        {
            table = new LinkedHashEntry[Iller,Ilceler];
           
        }
        public void OtelEkle(string ıl,string ılce, object value)
        {
            int hash1 = SifreOlustur(ıl)%Iller;
            int has2 = (SifreOlustur(ılce)+hash1)%Ilceler;
            if (table[hash1,has2] == null)
                table[hash1,has2] = new LinkedHashEntry(ıl,ılce,value);
            else
            {
                LinkedHashEntry entry = table[hash1,has2];
                while (entry.Next != null)//&& entry.Anahtar1 != ıl&&entry.Anahtar2!=ılce
                    entry = entry.Next;
                entry.Next = new LinkedHashEntry(ıl, ılce, value);
            }
        }
            private int SifreOlustur(string deger)
            {
                char[] dizi = deger.ToCharArray();
                int sayac = 0;
                int Sifre = 0;
                for(int k=0;k<dizi.Length;k++)
                {
                    for (int i = 'a'; i < 'z'; i++)
                    {
                        if (dizi[k] == i)
                        {
                            Sifre += sayac;
                            break;
                        }
                        sayac++;
                    }
                    sayac = 0;
                }
                return Sifre;
             }
        
        public Otel[] il_ve_ilceye_gore(string il,string ilce)
        {
            int hash1 = SifreOlustur(il)%Iller;
            int hash2 = (SifreOlustur(ilce)+hash1)%Ilceler;
            if (table[hash1,hash2] == null)
                return null;
            else
            {
                Otel[] otel = new Otel[0];
                int sayac = 0;
                LinkedHashEntry entry = table[hash1,hash2];
                while (entry != null && entry.Anahtar1 == il&&entry.Anahtar2==ilce)
                {
                    Array.Resize(ref otel, otel.Length + 1);
                    otel[sayac++] = (Otel)entry.deger;
                    entry = entry.Next;
                }

                return otel;
            }
        }
        public Otel[] ile_gore(string il)
        {
            Otel[] otel = new Otel[0];
            int hash1 = SifreOlustur(il) % Iller;
            int sayac = 0;
            int nulldeger = 0;
            for (int i = 0; i < Ilceler; i++)
            {
                if (table[hash1, i] == null)
                    continue;
                else
                {
                    LinkedHashEntry entry = table[hash1, i];
                    while (entry != null && entry.Anahtar1 == il)
                    {
                        nulldeger++;
                        Array.Resize(ref otel, otel.Length + 1);
                        otel[sayac++] = (Otel)entry.deger;
                        entry = entry.Next;
                    }
                }
            }
            if (nulldeger == 0)
                return null;
            else
                return otel;
            
        }
        private Otel [] Yildizsırala(Otel[] otel)
        {
            int i, j;
            Otel moved;
            for (i = 1; i < otel.Length; i++)
            {
                moved = otel[i];
                j = i;
                while (j > 0 && otel[j - 1].YildizSayisi < moved.YildizSayisi)
                {
                    otel[j] = otel[j - 1];
                    j--;
                }
                otel[j] = moved;
            }
            return otel;
        }
        private Otel[] sırala(Otel[] otel)
        {
            int i, j;
            Otel moved;
            for (i = 1; i < otel.Length; i++)
            {
                moved = otel[i];
                j = i;
                while (j > 0 && otel[j - 1].OtelPuani < moved.OtelPuani)
                {
                    otel[j] = otel[j - 1];
                    j--;
                }
                otel[j] = moved;
            }
            return otel;
        }
        public Otel[] OtelGetir(int param,string il,string ilce)
        {
            switch (param)
            {
                case 1:
                    return ile_gore(il);
                case 2:
                    return il_ve_ilceye_gore(il, ilce); 
                case 3:
                    return sırala(ile_gore(il));
                case 4:
                    return sırala(il_ve_ilceye_gore(il, ilce));
                case 5:
                    return Yildizsırala(ile_gore(il));
                case 6:
                    return Yildizsırala(il_ve_ilceye_gore(il, ilce));
                default:
                    return null;
                    
            }
            
        }
    }
}
