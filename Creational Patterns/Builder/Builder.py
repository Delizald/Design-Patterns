"""
Separate the construction of a complex object from its representation so
that the same construction process can create different representations.
"""

import abc

class Director:

    def __init__(self):
        self._builder = None

    def construct(self, builder):
        self._builder = builder
        self._builder._build_part_a()
        self._builder._build_part_b()
        self._builder._build_part_c()

class ConcreteBuilder(Builder):

    def _build_part_a(self):
        pass
    
    def _build_part_b(self):
        pass
    
    def _build_part_c(self):
        pass

class Product:
    """
    Represent the complex object under construction.
    """

    pass

def main():
    concrete_builder = ConcreteBuilder()
    director = Director()
    director.construct(concrete_builder)
    product = concrete_builder.product

if __name__ == "__main__":
    main()