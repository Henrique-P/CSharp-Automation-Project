#language: pt


Funcionalidade: Testar o carrinho sem o login prévio

  Contexto: 
    Dado que estou na pagina home

  @test3
  Cenario: Adicionar um produto ao carrinho e então o remover
    Quando clico na pagina de um produto
    E adiciono o produto ao carrinho
    E prossigo até o carrinho
    E removo o item do carrinho
    Então devo ver 'Your shopping cart is empty.' no carrinho

  @test4
  Cenario: Adicionar dois produtos ao carrinho e então os remover
    Quando clico na pagina de um produto
    E adiciono o produto ao carrinho
    E seleciono Continue shopping
    E retorno a Home
    E clico na segunda pagina de um produto
    E adiciono o produto ao carrinho
    E prossigo até o carrinho
    E removo ambos itens do carrinho
    Então devo ver 'Your shopping cart is empty.' no carrinho