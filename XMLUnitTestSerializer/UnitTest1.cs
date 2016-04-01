using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLSerializerLogic;

namespace XMLUnitTestSerializer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Serialize_PrimitiveBooleanData_BooleanXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(true);
            Assert.AreEqual("<Boolean>True</Boolean>", data, "Expected a boolean XML");
        }

        [TestMethod]
        public void Serialize_PrimitiveStringData_StringXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize("Hola");
            Assert.AreEqual("<String>Hola</String>", data, "Expected a string xml");
        }

        [TestMethod]
        public void Serialize_PrimitiveDateDataDateTimeXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(DateTime.Today);
            Assert.AreEqual("<DateTime>3/31/2016 12:00:00 AM</DateTime>",
                data, "Expected a DateTime xml");
        }

        [TestMethod]
        public void Serialize_PrimitiveCharData_CharXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize('C');
            Assert.AreEqual("<Char>C</Char>", data, "Expected a char xml");
        }


        [TestMethod]
        public void Serialize_PrimitiveIntData_IntXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(20);
            Assert.AreEqual("<Int32>20</Int32>", data, "Expected an int xml");
        }

        [TestMethod]
        public void Serialize_PrimitiveDoubleData_DoubleXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(3.25);
            Assert.AreEqual("<Double>3.25</Double>", data, "Expected a double xml");
        }

        [TestMethod]
        public void Serialize_PrimitiveDecimalData_DecimalXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(3.25M);
            Assert.AreEqual("<Decimal>3.25</Decimal>", data, "Expected a decimal xml");
        }

        [TestMethod]
        public void Serialize_PrimitiveFloatData_FloatXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(3.25F);
            Assert.AreEqual("<Single>3.25</Single>", data, "Expected a float xml");
        }

        [TestMethod]
        public void Serialize_ClassDataWithSimpleFieldsAndProperties_PersonaXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(new Persona());
            Assert.AreEqual("<Persona>\n\t<Nombre>Ale</Nombre>\n\t<Edad>20</Edad>\n" +
                            "\t<NumCuenta>21351064</NumCuenta>\n</Persona>",
                    data, "Expected a Persona xml");
        }
    }
}
