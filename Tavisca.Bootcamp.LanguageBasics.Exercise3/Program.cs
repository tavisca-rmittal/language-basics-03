using System;
using System.Linq;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }
                   


        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }


	public static int maxValue(int[] chancesOfMax,List<int> ls)
        { 
	  int num=chancesOfMax[ls[0]];
          if(ls.Count != 1)
          {
		foreach(int i in ls)
          	{ 
	          if(num<chancesOfMax[i])
            	  {
                  num=chancesOfMax[i];
                  }
          	}
          }
          return num;
        }
        public static int minValue(int[] chancesOfMin,List<int> ls)
        {
	  int num=chancesOfMin[ls[0]];
          if(ls.Count != 1)
          {
	     foreach(int i in ls)
                { 
		  if(num>chancesOfMin[i])
            	  {
                  num=chancesOfMin[i];
                  }
                }
          }
          return num;
        }

         public static List<int> IndexOfAll(int[] prob,List<int> ls,int val)
         { 
             List<int> resindex=new List<int>();
             foreach(int x in ls)
             { 
                 if(prob[x]==val)
                 { 
                    resindex.Add(x);
                 }
             }
             return resindex;

         }
	

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.

	    int length1=protein.Length;
            int[] cal=new int[length1];
            for(int i=0;i<length1;i++)
            { 
		cal[i]=protein[i]*5 + carbs[i]*5 + fat[i]*9;
	    }   
            int maxProtein=protein.Max();
         
            int maxFat=fat.Max();
           
            int maxCal=cal.Max();
         
            int[] res=new int[dietPlans.Length];
            
            for(int i=0;i<dietPlans.Length;i++)
            {

               List<int> ls = new List<int>();
              for(int k=0;k<length1;k++)
              { 
                  ls.Add(k);
              }


              int maxv=0;
              int minv=0;
	      //arr index of dietplan have string like CpF.To convert every index into char arr
              char[] arr=dietPlans[i].ToCharArray();
              if(arr.Length==0)
              {
                  res[i]=0;
                  continue;
              }
              for(int j=0;j<arr.Length;j++)
              { 
		  switch(arr[j])
                      {
                         case 'C': maxv=maxValue(carbs,ls);
                                   ls = IndexOfAll(carbs,ls,maxv);
                                   break;
		         case 'c': minv=minValue(carbs,ls);
                                   ls=IndexOfAll(carbs,ls,minv);
                             	   break;
                         case 'P': maxv=maxValue(protein,ls);
                             	   ls=IndexOfAll(protein,ls,maxv);
                                   break;
                         case 'p': minv=minValue(protein,ls);
                         	   ls=IndexOfAll(protein,ls,minv);
                             	   break;
                         case 'F': maxv=maxValue(fat,ls);
                                   ls=IndexOfAll(fat,ls,maxv);
                             	   break;
                    	 case 'f': minv=minValue(fat,ls);
                                   ls=IndexOfAll(fat,ls,minv);
                                   break;
                         case 'T': maxv=maxValue(cal,ls);
                                   ls=IndexOfAll(cal,ls,maxv);
                             	   break;
                    	 case 't': minv=minValue(cal,ls);
                             	   ls=IndexOfAll(cal,ls,minv);
                             	   break;
                      }
                if(ls.Count==1)
                {
                     res[i]=ls[0];
                     break;
                }
                
              }
              res[i]=ls[0];
               
                            
            }
          
            //throw new NotImplementedException();
           return res; 
        }
    }
}
          
