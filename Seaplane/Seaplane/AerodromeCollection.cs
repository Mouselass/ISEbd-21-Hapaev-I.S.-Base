using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaplane
{
    public class AerodromeCollection
    {

        readonly Dictionary<string, Aerodrome<Vehicle>> aerodromeStages;

        public List<string> Keys => aerodromeStages.Keys.ToList();

        private readonly int pictureWidth;

        private readonly int pictureHeight;

        private readonly char separator = ':';

        public AerodromeCollection(int pictureWidth, int pictureHeight)
        {
            aerodromeStages = new Dictionary<string, Aerodrome<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

        public void AddAerodrome(string name)
        {
            if (aerodromeStages.ContainsKey(name))
            {
                return;
            }

            aerodromeStages.Add(name, new Aerodrome<Vehicle>(pictureWidth, pictureHeight));
        }

        public void DelAerodrome(string name)
        {
            if (aerodromeStages.ContainsKey(name))
            {
                aerodromeStages.Remove(name);
            }
        }

        public Aerodrome<Vehicle> this[string ind]
        {
            get
            {
                if (aerodromeStages.ContainsKey(ind))
                {
                    return aerodromeStages[ind];
                }
                else
                {
                    return null;
                }
            }
        }       

        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"AerodromeCollection");

                    foreach (var level in aerodromeStages)
                    {
                        sw.WriteLine($"Aerodrome{separator}{level.Key}");

                        ITransport plane = null;

                        for (int i = 0; (plane = level.Value.GetNext(i)) != null; i++)
                        {
                            if (plane != null)
                            {
                                if (plane.GetType().Name == "Plane")
                                {
                                    sw.Write($"Plane{separator}");
                                }
                                if (plane.GetType().Name == "WaterPlane")
                                {
                                    sw.Write($"WaterPlane{separator}");
                                }

                                sw.WriteLine(plane);
                            }
                        }
                    }
                }
            }           
        }

        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }

            string str = "";

            using (StreamReader sr = new StreamReader(filename))
            {
                str = sr.ReadLine();

                if (str.Contains("AerodromeCollection"))
                {
                    aerodromeStages.Clear();
                }
                else
                {
                    throw new FormatException();
                }

                str = sr.ReadLine();
                Vehicle plane = null;
                string key = string.Empty;

                while (str != null && str.Contains("Aerodrome"))
                {
                    if (str.Contains("Aerodrome"))
                    {
                        key = str.Split(separator)[1];
                        aerodromeStages.Add(key, new Aerodrome<Vehicle>(pictureWidth, pictureHeight));
                    }

                    str = sr.ReadLine();

                    while (str != null && (str.Contains("Plane") || str.Contains("WaterPlane")))
                    {
                        if (str.Split(separator)[0] == "Plane")
                        {
                            plane = new Plane(str.Split(separator)[1]);
                        }
                        else if (str.Split(separator)[0] == "WaterPlane")
                        {
                            plane = new WaterPlane(str.Split(separator)[1]);
                        }

                        var result = aerodromeStages[key] + plane;

                        if (!result)
                        {
                            throw new NullReferenceException();
                        }

                        str = sr.ReadLine();
                    }
                }
            } 
        }
    }
}