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


	public static int maxval(int[] prob,List<int> ls)
        { 
	  int m=prob[ls[0]];
          if(ls.Count != 1)
          {
		foreach(int i in ls)
          	{ 
	          if(m<prob[i])
            	  {
                  m=prob[i];
                  }
          	}
          }
          return m;
        }
        public static int minval(int[] prob,List<int> ls)
        {
	  int m=prob[ls[0]];
          if(ls.Count != 1)
          {
	     foreach(int i in ls)
                { 
		  if(m>prob[i])
            	  {
                  m=prob[i];
                  }
                }
          }
          return m;
        }

         public static List<int> Indexofall(int[] prob,List<int> ls,int val)
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

	    int l1=protein.Length;
            int[] cal=new int[l1];
            for(int i=0;i<l1;i++)
            { 
		cal[i]=protein[i]*5 + carbs[i]*5 + fat[i]*9;
	    }   
            int maxprotein=protein.Max();
         
            int maxfat=fat.Max();
           
            int maxcal=cal.Max();
         
            int[] res=new int[dietPlans.Length];
            
            for(int i=0;i<dietPlans.Length;i++)
            {

               List<int> ls = new List<int>();
              for(int k=0;k<l1;k++)
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
                         case 'C': maxv=maxval(carbs,ls);
                                   ls = Indexofall(carbs,ls,maxv);
                                   break;
		         case 'c': minv=minval(carbs,ls);
                                   ls=Indexofall(carbs,ls,minv);
                             	   break;
                         case 'P': maxv=maxval(protein,ls);
                             	   ls=Indexofall(protein,ls,maxv);
                                   break;
                         case 'p': minv=minval(protein,ls);
                         	   ls=Indexofall(protein,ls,minv);
                             	   break;
                         case 'F': maxv=maxval(fat,ls);
                                   ls=Indexofall(fat,ls,maxv);
                             	   break;
                    	 case 'f': minv=minval(fat,ls);
                                   ls=Indexofall(fat,ls,minv);
                                   break;
                         case 'T': maxv=maxval(cal,ls);
                                   ls=Indexofall(cal,ls,maxv);
                             	   break;
                    	 case 't': minv=minval(cal,ls);
                             	   ls=Indexofall(cal,ls,minv);
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
          
