namespace SQL_Test
//Component, QtyPer from SQL Table BomStructure
//something1 from Class3
{
    class Class1
    {
        public string Component { get; set; }
        public string Description { get; set; }
        public string QtyPer { get; set; }

        public Class1(string Component, string Description, string QtyPer)
        {
            this.Component = Component;
            this.Description = Description;
            this.QtyPer = QtyPer;
        }
    }
}
