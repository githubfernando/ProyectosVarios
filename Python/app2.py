class A:
    def __init__(self, firstname, lastname):
        self.firstname = firstname
        self.lastname = lastname

class B(A):
    def __init__(self, firstname, age):
        A.__init__(self, firstname, "salman")
        self.age = age

val = B("Ahmed","25")
print (val.firstname + val.lastname + val.age)
        