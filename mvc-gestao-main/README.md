# mvc-gestao
Criando um Model

O Model representa uma tabela do banco de dados.

Exemplo: Produto
php artisan make:model Produto
Arquivo criado
app/Models/Produto.php
Exemplo:

<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Produto extends Model
{
    protected $fillable = [
        'nome',
        'descricao',
        'preco',
        'estoque'
    ];
}

Explicação
protected $fillable: define quais campos podem ser preenchidos em massa.
Cada instância de Produto representa um registro da tabela produtos.

2. Criando uma Migration

A Migration cria ou altera tabelas no banco de dados.

php artisan make:migration create_produtos_table
Arquivo criado
database/migrations/xxxx_xx_xx_create_produtos_table.php
Exemplo de código
public function up()
{
    Schema::create('produtos', function (Blueprint $table) {
        $table->id();
        $table->string('nome');
        $table->text('descricao')->nullable();
        $table->decimal('preco', 10, 2);
        $table->integer('estoque')->default(0);
        $table->timestamps();
    });
}
Executando a migration
php artisan migrate

3. Criando Model + Migration juntos

Você pode criar os dois ao mesmo tempo:

php artisan make:model Produto -m
4. Criando um Controller

O Controller contém a lógica da aplicação.

php artisan make:controller ProdutoController
Arquivo criado
app/Http/Controllers/ProdutoController.php
Controller com métodos CRUD
php artisan make:controller ProdutoController --resource
Métodos criados automaticamente
index()
create()
store()
show()
edit()
update()
destroy()
5. Criando Model + Migration + Controller
php artisan make:model Produto -mc
O comando acima cria:
app/Models/Produto.php
database/migrations/...create_produtos_table.php
app/Http/Controllers/ProdutoController.php
6. Criando tudo com Controller Resource
php artisan make:model Produto -mcr
Opções utilizadas
-m → migration
-c → controller
-r → controller resource
7. Criando uma View

As Views ficam na pasta:

resources/views/
Exemplo de estrutura
resources/views/produtos/
    index.blade.php
    create.blade.php
    edit.blade.php
    show.blade.php
Criando manualmente
mkdir -p resources/views/produtos
touch resources/views/produtos/index.blade.php
Exemplo de index.blade.php
<h1>Lista de Produtos</h1>

@foreach ($produtos as $produto)
    <p>{{ $produto->nome }} - R$ {{ $produto->preco }}</p>
@endforeach
8. Definindo Rotas

No arquivo routes/web.php:

use App\Http\Controllers\ProdutoController;

Route::resource('produtos', ProdutoController::class);

Essa rota cria automaticamente todas as rotas CRUD.

9. Exemplo do método index() no Controller
public function index()
{
    $produtos = Produto::all();
    return view('produtos.index', compact('produtos'));
}
10. Fluxo MVC
Usuário acessa URL
        ↓
      Route
        ↓
   Controller
        ↓
      Model
        ↓
 Banco de Dados
        ↓
      View
        ↓
   Resposta ao Usuário
11. Comando mais usado no dia a dia
php artisan make:model Produto -mcr

Esse comando cria praticamente tudo o que você precisa para iniciar um CRUD.

12. Trabalhando no GitHub Codespaces

Se você estiver desenvolvendo no GitHub Codespaces, os comandos são executados normalmente no terminal integrado do ambiente.

Iniciar o servidor local
php artisan serve
Instalar dependências
composer install
npm install
npm run dev
13. Resumo dos comandos
Comando	Função
php artisan make:model Produto	Cria apenas o Model
php artisan make:migration create_produtos_table	Cria a Migration
php artisan make:controller ProdutoController	Cria o Controller
php artisan make:controller ProdutoController --resource	Cria Controller com CRUD
php artisan make:model Produto -m	Model + Migration
php artisan make:model Produto -mc	Model + Migration + Controller
php artisan make:model Produto -mcr	Model + Migration + Controller Resource
14. Estrutura final gerada
app/
 ├── Models/
 │   └── Produto.php
 │
 └── Http/
     └── Controllers/
         └── ProdutoController.php

database/
 └── migrations/
     └── xxxx_xx_xx_create_produtos_table.php

resources/
 └── views/
     └── produtos/
         ├── index.blade.php
         ├── create.blade.php
         ├── edit.blade.php
         └── show.blade.php

routes/
 └── web.php
15. Recomendação

Para criar rapidamente toda a estrutura inicial de um CRUD, use:

php artisan make:model Produto -mcr
