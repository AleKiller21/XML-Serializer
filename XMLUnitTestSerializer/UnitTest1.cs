using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLSerializerLogic;
using XMLUnitTestSerializer.TestClasses;

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
            Assert.AreEqual("<DateTime>4/1/2016 12:00:00 AM</DateTime>",
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
        public void Serialize_ClassDataWithSimpleFields_PersonaFieldsXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(new PersonaFields());
            Assert.AreEqual("<PersonaFields>\n\t<Nombre>Ale</Nombre>\n\t<Edad>20</Edad>\n</PersonaFields>",
                            data, "Expected a PersonaFields xml");
        }

        [TestMethod]
        public void Serialize_ClassDataWithSimpleProperties_PersonaPropertiesXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(new PersonaProperties());
            Assert.AreEqual("<PersonaProperties>\n\t<NumCuenta>21351064</NumCuenta>\n\t" +
                            "<Universidad>Unitec</Universidad>\n</PersonaProperties>",
                            data, "Expected a PersonaProperties xml");
        }

        [TestMethod]
        public void Serialize_ClassDataWithSimpleFieldsAndProperties_PersonaXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(new Persona());
            Assert.AreEqual("<Persona>\n\t<Nombre>Alejandro</Nombre>\n\t" +
                            "<Edad>20</Edad>\n\t<Direccion>San Pedro Sula</Direccion>\n\t" +
                            "<Colonia>Montecarlo</Colonia>\n</Persona>",
                            data, "Expected a Persona xml");
        }

        [TestMethod]
        public void Serialize_ClassWithNestedClass_PersonaAddressXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(new PersonaAddress());
            Assert.AreEqual("<PersonaAddress>\n\t<Name>Alejandro</Name>\n\t" +
                            "<Genre>Male</Genre>\n\t<Address>\n\t\t" +
                            "<City>San Pedro Sula</City>\n\t\t" +
                            "<HomeAddress>Col. Montecarlo</HomeAddress>\n\t\t" +
                            "<HouseNumber>5678</HouseNumber>\n\t</Address>\n" +
                            "</PersonaAddress>",
                            data, "Expected a PersonaAddress xml");
        }

        [TestMethod]
        public void Serialize_ClassWithAttributes_PersonaAttributesXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(new PersonaAttributes());
            Assert.AreEqual("<PersonaAttributes>\n\t<Edad>20</Edad>\n\t" +
                            "<Nombre>Goku</Nombre>\n\t<Direccion>San Pedro Sula</Direccion>\n\t" +
                            "<Colonia>Montecarlo</Colonia>\n" +
                            "</PersonaAttributes>",
                            data, "Expected a PersonaAddress xml");
        }

        [TestMethod]
        public void Serialize_ClassWithPrimitiveArrayElements_PersonaAttributesXML()
        {
            XMLSerializer serializer = new XMLSerializer();
            var data = serializer.Serialize(new PersonaArrays());
            Assert.AreEqual("<PersonaArrays>\n\t<Name>Alejandro</Name>\n\t" +
                            "<Age>20</Age>" +
                            "\n\t<TopAnime>DBZ</TopAnime>" +
                            "\n\t<TopAnime>Fairy Tail</TopAnime>" +
                            "\n\t<TopAnime>Bleach</TopAnime>" +
                            "\n\t<TopAnime>Saint Seiya</TopAnime>" +
                            "\n\t<TopAnime>Naruto</TopAnime>" +
                            "\n\t<TopAnime>Yugioh</TopAnime>" +
                            "\n</PersonaArrays>",
                            data, "Expected a PersonaArrays xml");
        }
    }
}
