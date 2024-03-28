using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET8
{
    public class POCO
    {
        public int Id { get; set;}
        public string Name { get; set;}
    }

    sealed public class TestInterview
    {
        public async Task DoSomething(int id, Configuration configuration)
        {
            IEnumerable<MyType> propertyTypeDatas = await Provider.GetDataTypes();

            IEnumerable<MyData> originalValueData = await Provider.GetData(Id);

            List<MyData> updatedValueData = [];

            MyData title = SetProperty("title", configuration.Title);
            MyData myId = SetProperty("my_id", configuration.MyId.ToString());
            SetProperty("instructions", configuration.Instructions);
            SetProperty("logoType", configuration.LogoType);
            SetProperty("allowAttachments", configuration.IsAllowAttachments.ToString().ToLower());

            foreach (Translation translation in configuration.Translations ?? new())
            {
                if (translation.Title != null)
                {
                    title.Options ??= new();
                    title.Options?.Add(new OptionsData() { OptionKey = translation.Language, OptionValue = translation.Title });
                }

                if (translation.AwdId != null)
                {
                    awdId.Options ??= new();
                    awdId.Options.Add(new OptionsData() { OptionKey = translation.Language, OptionValue = translation.AwdId.ToString() });
                }
            }

            await Provider.SetData(updatedValueData);

            MyData SetProperty(string typeName, string? value)
            {
                MyData? myData = originalValueData.FirstOrDefault(p => p.TypeId == ParsedTypeIdFromName(propertyTypeDatas, typeName));

                if (myData != null)
                {
                    myData.Value = value;
                }
                else
                {
                    myData = new()
                    {
                        Id = id,
                        TypeId = ParsedTypeIdFromName(propertyTypeDatas, typeName) ?? throw new Exception("Invalid type"),
                        Value = value,
                    };
                }
                updatedValueData.Add(myData);
                return myData;
            }
        }
    }
}
