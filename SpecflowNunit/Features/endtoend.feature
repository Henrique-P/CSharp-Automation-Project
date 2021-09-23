#language: pt

Funcionalidade: Testar a compra de um produto de ponta a ponta.

   Contexto:
    Dado que estou na pagina de login
    Quando preencho os campos email e senha com "novoemailteste@gmail.com" e "teste123"
    E clico em Sign in
    Então devo ver "MY ACCOUNT" na área logada

@endtoend
  Cenario: Fazer um pedido.
    Dado que estou logado e na pagina home
    Quando clico na pagina de um produto
    E adiciono o produto ao carrinho
    E prossigo até o carrinho
    E prossigo para a pagina de endereço
    E prossigo para a pagina de forma de entrega
    E prossigo para a pagina de forma de pagamento
    E seleciono a forma de pagamento Bankwire
    E clico em Finalizar pedido
    Então devo ver 'Your order on My Store is complete.' na pagina final