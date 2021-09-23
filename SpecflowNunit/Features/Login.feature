#language: pt
Funcionalidade: Testar a funcionalidade de login

@mytag
Cenario: Teste positivo do login
	Dado que estou na pagina de login
    Quando preencho os campos email e senha com "novoemailteste@gmail.com" e "teste123"
    E clico em Sign in
    Então devo ver "MY ACCOUNT" na área logada

Esquema do Cenario: Teste negativo de login
    Dado que estou na pagina de login
    Quando preencho os campos email e senha com <email> e <senha>
    E clico em Sign in
    Então devo ver uma mensagem <alerta>

    Exemplos:
      | email                      | senha             | alerta                       |
      | "novoemailteste@gmail.com" | "senha incorreta" | "Authentication failed."     |
      | "usuário incorreto"        | "teste123"        | "Invalid email address."     |
      | ""                         | "teste123"        | "An email address required." |
      | "novoemailteste@gmail.com" | ""                | "Password is required."      |