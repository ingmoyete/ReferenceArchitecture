using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using referenceArchitecture.Core.DTO;
using referenceArchitecture.repository.Edmx.Interfaces;
using referenceArchitecture.repository._0.__Edmx;

namespace referenceArchitecture.repository.ExampleRepository
{
    public class ExampleRepository : IExampleRepository
    {
        public List<DTOExample> getAllUsers(IDbContext context)
        {
            return context.Examples.AsNoTracking().Select(x => new DTOExample
            {
                FirstField = x.FIELD1,
                SecondField = x.FIELD2,
                ThirdField = x.FIELD3,
                Identificator = x.ID
            }).ToList();
        }
        public void insertarExample(IDbContext context, DTOExample example)
        {
            Example entity = getEntityFromDTOExample(example);

            context.Examples.Add(entity);
        }

        public DTOExample getDTOExample(IDbContext context, DTOExample example)
        {
            return context.Examples.AsNoTracking()
                .Where
                (
                    x => x.FIELD1 == example.FirstField
                        && x.FIELD2 == example.SecondField
                        && x.FIELD3 == example.ThirdField
                )
                .Select(x => new DTOExample
                {
                    FirstField = x.FIELD1,
                    SecondField = x.FIELD2,
                    ThirdField = x.FIELD3,
                    Identificator = x.ID
                }).FirstOrDefault();
        }

        private Example getEntityFromDTOExample(DTOExample example)
        {
            Example entity = new Example
            {
                FIELD1 = example.FirstField,
                FIELD2 = example.SecondField,
                FIELD3 = example.ThirdField
            };

            return entity;
        }
      
    }
}
