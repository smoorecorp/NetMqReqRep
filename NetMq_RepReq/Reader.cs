using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO; 

namespace NetMq.ReqRep.PeopleService
{
    /// <summary>
    /// Reader Class contains methods to read and parse a comma delimited file
    /// </summary>
    public class Reader
    {
        
        public List<IPerson> ReadData( string path )
        {
            List<IPerson> people = new List<IPerson>();
            
            using (TextFieldParser textFieldParser = new TextFieldParser(path))
            {
                textFieldParser.Delimiters = new string[] { "," };

                while (!textFieldParser.EndOfData)
                {
                    string[] detail = textFieldParser.ReadFields();

                    if (detail != null && (textFieldParser.LineNumber - 1) != 1)
                        people.Add(new Person() { Id = detail[0], FirstName = detail[1], LastName = detail[2], City = detail[3], State = detail[4], Country = detail[5] });
                }
            }
            return people;
        }

        
            
    }
}
