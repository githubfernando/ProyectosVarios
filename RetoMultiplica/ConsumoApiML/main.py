from multiprocessing.dummy import current_process
import requests
import json

from Producto import Producto


#site_id: (obligatorio) string que representa el país.
#status: puede ser que si bien el producto está identificado dentro de nuestro catálogo, aún no es elegible para asociar a una publicación.
#   status=active: devuelve aquellos productos que ya pueden elegirse para asociar a una publicación.
#   status=inactive: devuelve aquellos productos que todavía no son elegibles para asociar a una publicación.
#q: string con palabras claves de búsqueda. Ejemplo: “Celular Samsung Galaxy S8”. Obligatorio en caso no se envíe un product_identifier.
#product_identifier: (obligatorio) string con el código universal del producto. Ejemplo: GTIN el cual engloba los diferentes PIs (EAN, UPC, ISBN, etc). Obligatorio en caso no se envíe una cadena de palabras claves.
#domain_id: (opcional) string con el dominio en el cual se quiere publicar.
#offset: (opcional) posición desde la que se devuelven los resultados de la búsqueda.
#limit: (opcional) cantidad de resultados que devuelve la búsqueda.

if __name__ == '__main__':

    #Parametros
    #url general
    url = "https://api.mercadolibre.com/"

    uriProducts = 'products/search'
    uriProductsItem = 'products/{0}/items'
    uriItem = 'items/'
    uriUsers = 'users/'
    uriItemUsers = 'users/{0}/items/search' #Catalogo del vendedor
    #argsRequestItemUsers = {'status':'active','tags':'catalog_boost'} sin autorizacion para consumir este endpoint
    parametroCantRegistros = 50


    #Request
    site_id = "MCO"
    status = "active"
    q="Motorola"
    limit = 100
    argsRequest = {'status':status,'site_id':site_id,'q':q,'limit':limit}
    response  = requests.get(url+uriProducts, params = argsRequest)

    cantResultados = 0

    if response.status_code == 200:
        #content = response.content
        
        jresponse = json.loads(response.text)
        #total = jresponse['paging']['total']
        jresults = jresponse['results']
        for result in jresults:

            productoId = result['id'] #Product id
            nombreProducto = result['name']
            response = requests.get(url+uriProductsItem.format(productoId)) #Items de Product id

            if response.status_code == 200:

                jrProductItems = json.loads(response.text)
                resultPItems = jrProductItems['results'] #Items

                for rItem in resultPItems:

                    itemId = rItem['item_id']
                    response = requests.get(url+uriItem+itemId)

                    if response.status_code == 200:

                        jItem = json.loads(response.text)
                        
                        price = jItem['price']
                        condition = jItem['condition']
                        acceptMercadoPago = jItem['accepts_mercadopago']
                        paymentMethods = jItem['non_mercado_pago_payment_methods']

                        idVendedor = jItem['seller_id']
                        ciudadVendedor = jItem['seller_address']['city']['name']
                        paisVendedor = jItem['seller_address']['country']['name']

                        cantResultados+=1

                        if(cantResultados==parametroCantRegistros):
                            break

                        response = requests.get(url+uriUsers+str(idVendedor))

                        if(response.status_code==200):

                            jUser = json.loads(response.text)
                            nombre = jUser['nickname']

                        oProducto = Producto()

                        oProducto.AddProduct(itemId,productoId,price,condition,nombre,idVendedor,ciudadVendedor,paisVendedor,
                        acceptMercadoPago,nombreProducto,str(paymentMethods))

                
            if(cantResultados==parametroCantRegistros):
                break
            



        
    
    
    






