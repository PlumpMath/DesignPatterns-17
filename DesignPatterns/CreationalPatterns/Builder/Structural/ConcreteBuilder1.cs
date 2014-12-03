﻿namespace DesignPatterns.CreationalPatterns.Builder.Structural
{
    class ConcreteBuilder1 : CreationalPatterns.Builder.Structural.Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartA");
        }

        public override void BuildPartB()
        {
            _product.Add("PartB");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
}