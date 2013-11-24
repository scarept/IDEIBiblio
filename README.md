# IDEIBiblio  #
__________
# Objectivos :#
- Implementação de uma loja Web permitindo aos utilizadores efectuarem compras online.
- O cliente tem de se registar e fazer login para poder efectuar compras
- A empresa usa duas empresas externas para o envio das encomendas, LogisticaSA e ShippingAll
- A empresa tem uma parceria com a empresa AnalisaMercados que analisa diariamente os preços praticados pela concorrência e gera uma lista de produtos cujo o preço deve ser revisto
- Ter uma interface de gestão de produtos (inserção, actualização e remoção)
- O cliente deve ter um carrinho onde adiciona os itens que vai comprar, este deve ser guardado entre a sessão actual e a próxima
- Ter uma interfac e de gestão de encomendas(inserção e actualização)
- O cliente deve ter uma lista de sugestões relacionado com as suas compras habituais


----------

# Funcionalidades: #
- Cliente deve conseguir registar-se
- Existem outros tipos de utilizadores como Administrador e Gestor de Produtos
- Envio de encomendas pela empresa ShippingAll ou LogisticaSA dependendo de qual faz o melhor preço de envio
- Cliente deve conseguir fazer login para comprar artigos
- Cliente adiciona produtos ao carrinho
- Cliente faz checkout do carrinho
- É calculado o custo de envio e total da encomenda para o ponto anterior
- Deve-se guardar o estado do carrinho ao fazer logout para ser carregado no próximo inicio de sessão
- Deve ser possível inserir e actualizar encomendas
- Para ajudar o cliente deve-se fornecer uma lista de sugestões através das suas compras habituais e/ou últimas pesquisas
- Inserir a primeira parte do trabalho como Widget na loja actual
## ShippingAll ##
- ShippingAll é um WebService que deve ser implementado
- O WebService deve ter uma regra de calculo do preço de envio
- O WebService deve ter uma função para o envio da encomenda
## LogisticaSA ##
- LogisticaSA é um WebService que deve ser implementado
- O WebService deve ter uma regra de calculo do preço de envio
- O WebService deve ter uma função para o envio da encomenda
## AnalisaMercados ##
- AnalisaMercados é um WebService que deve ser implementado
- Deve analisar o preço dos livros de outras empresas, comprar esse preço ao catálogo da empresa IDEIBiblio e dizer quais as alterações de preços que devem ser feitas


----------

# Valorizações: #
- Utilização de funcionalidades da Framework .Net
	1. Themes
	2. Skin
	3. Web Parts
	4. Navigation
	5. Profiles
- Enviar email ao cliente quando a compra é registada
- Utilização de uma biblioteca de JavaScript, como por exemplo, JQuery ou GWT
- Utilização de Ajax.Net

----------
# Tecnologias a usar #
- .Net no Front-End com o cliente
- .Net no serviço LogisticaSA
- PHP no serviço ShippingAll
- PHP na empresa AnalisaMercados
- MySQL para a base de dados do ShippingAll
- MySQL para a base de dados do AnalisaMercados
- SQL Server para a base de dados do LogisticaSA
- Utilização de WebServices para comunicar com as empresas externas
- Logging para os erros e excepções geradas


----------

# Notas #
- Não implementar mais do que pedido
- O modelo de dominio e de dados deve ser simplificado, apenas devem considerar o necessário para resolver os requisitos funcionais pedidos.


----------

# Desenvolvido por: #
**Marcio Martins** (martinsmas)
&
**Ricardo Brandão** (1111121RicardoBrandao)
