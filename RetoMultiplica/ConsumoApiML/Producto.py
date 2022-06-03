import pyodbc

class Producto:

    server = 'localhost'
    bd='SouthCoreData'
    user = 'sa'
    password = 'sa'

    def AddProduct(self, ItemId, ProductoId, Precio, Condicion, NombreVendedor, IdCuentaVendedor, CiudadVendedor, PaisVendedor
    ,AceptaMercadoPago,NombreProducto,MetodosDePago):
        try:
            connstr = "Driver={ODBC Driver 17 for SQL server}; Server=localhost;DATABASE=SouthCoreData;UID=user;PWD=user"
            conexion = pyodbc.connect(connstr)

            cursor = conexion.cursor()
            query = ('INSERT INTO Consulta_Productos (ItemId, ProductoId, Precio, Condicion, NombreVendedor, IdCuentaVendedor, CiudadVendedor, PaisVendedor, AceptaMercadoPago, NombreProducto, MetodosDePago)'
            'Values(?,?,?,?,?,?,?,?,?,?,?)')
            cursor.execute(query,[ItemId,ProductoId,Precio,Condicion,NombreVendedor,IdCuentaVendedor,CiudadVendedor
            ,PaisVendedor, AceptaMercadoPago,NombreProducto,MetodosDePago])

            cursor.commit()

            print('conexión a la BD exitosa.')

        except Exception:
            print('error al intentar conectarse a la BD')