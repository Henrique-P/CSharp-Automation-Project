#language: pt


Funcionalidade: Testar funcionalidades do carrinho sem o login prévio

  Contexto: 
    Dado que estou na pagina home

  @test3
  Cenario: Adicionar um produto ao carrinho e então o remover
    Quando adiciono o produto numero '1' da home page ao carrinho
    E prossigo até o carrinho
    E removo o item do carrinho
    Então devo ver 'Your shopping cart is empty.' no carrinho

  @test4
  Cenario: Adicionar dois produtos ao carrinho e então os remover
    Quando adiciono o produto numero '1' da home page ao carrinho
    E seleciono Continue shopping
    E adiciono o produto numero '2' da home page ao carrinho
    E prossigo até o carrinho
    E removo ambos itens do carrinho
    Então devo ver 'Your shopping cart is empty.' no carrinho


  Cenario: Editar a cor de um produto e adicionar-lo ao carrinho
    Quando clico na pagina de um produto
    E altero sua cor
    E clico em Add to Cart
    E prossigo até o carrinho
    Então devo ver 'Color : Blue, Size : S' no produto dentro do carrinho