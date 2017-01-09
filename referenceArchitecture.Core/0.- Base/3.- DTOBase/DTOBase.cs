using referenceArchitecture.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using referenceArchitecture.Core.Helpers;
using System.Reflection;

namespace referenceArchitecture.Core.Base.DTOBase
{
    public abstract class DTOBase : IDTOBase
    {
        ///<summary>
        /// Helper to get variables from app.config.
        /// </summary>
        private Ihp _hp = DependencyResolver.Current.GetService<Ihp>();
        public Ihp hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        /// <summary>
        /// Resources object to get strings from csv.
        /// </summary>
        private IResource globalResources = DependencyResolver.Current.GetService<IResource>();
        public IResource GlobalResources
        {
            get
            {
                globalResources.getResources(hp.getStringFromAppConfig("globalResourceFileName"));
                return globalResources;
            }
            set { globalResources = value; }
        }


        /// <summary>
        /// Collection of validation results.
        /// </summary>
        private List<ValidationResult> validationResultCollection = new List<ValidationResult>();
        public List<ValidationResult> ValidationResultCollection
        {
            get { return validationResultCollection; }
            set { validationResultCollection = value; }
        }

        /// <summary>
        /// Get a collection of DTO properties by names.
        /// </summary>
        /// <param name="validationContext">The validation context of the attribute.</param>
        /// <param name="propertyNames">The property name whose values will be retrived.</param>
        /// <returns>A collection with property values (same order as the one provided with the propertyNames).</returns>
        public List<object> getDTOPropertiesByNames(ValidationContext validationContext, params string[] propertyNames)
        {
            // Get DTO
            var dto = validationContext.ObjectInstance;
            var dtoType = dto.GetType();

            // get DTOBase
            var dtoBase = validationContext.ObjectInstance as DTOBase;

            // Get all properties through a loop
            List<object> properties = new List<object>();
            foreach (var propertyName in propertyNames)
            {
                // Get value of a single property
                PropertyInfo propertyInfo = dtoType.GetProperty(propertyName);
                object value = propertyInfo.GetValue(dtoBase);


                // insert value in collection
                properties.Add(value);
            }

            return properties;
        }

    }
}
