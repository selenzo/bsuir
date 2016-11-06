<?php
use yii\helpers\Html;
use yii\bootstrap\ActiveForm;


/* @var $this yii\web\View */
/* @var $form yii\bootstrap\ActiveForm */
/* @var $model app\models\LoginForm */
//
//$this->title = 'Login';
//$this->params['breadcrumbs'][] = $this->title;

$this->title = 'Home';
?>

<h1>Here could be your advertising</h1>
<br>

<!-- Button trigger modal -->
<button class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
        Developers
      </button>

<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">SPP 2015</h4>
      </div>
      <div class="modal-body">
        place for names of greatest developers ever
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
      </div>
    </div>
  </div>
</div>
