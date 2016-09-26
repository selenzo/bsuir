<?php
use yii\helpers\Html;
use yii\helpers\VarDumper;
use yii\bootstrap\ActiveForm;

/* @var $this yii\web\View */
/* @var $form yii\bootstrap\ActiveForm */
/* @var $model app\models\LoginForm */

$this->title = 'Create';
$this->params['breadcrumbs'][] = $this->title;
?>

<div class="container">
   
   
   
   
   <?php $form = ActiveForm::begin([
        'id' => 'login-form',
        'options' => ['class' => 'form-horizontal'],
        'fieldConfig' => [
            'template' => "{label}\n<div class=\"col-lg-3\">{input}</div>\n<div class=\"col-lg-8\">{error}</div>",
            'labelOptions' => ['class' => 'col-lg-1 control-label'],
        ],
    ]); ?>

    <?= $form->field($model, 'name') ?>

    <?= $form->field($model, 'email')?>
    
    <?= $form->field($model, 'mobile')?>

    <div class="form-group">
        <div class="col-lg-offset-1 col-lg-11">
            <?= Html::submitButton('Create', ['class' => 'btn btn-success', 'name' => 'create-button']) ?>
             <?= Html::submitButton('Cancel', ['class' => 'btn', 'name' => 'cancel-button', 'onClick' => 'javascript:history.back()']) ?>
            
            
<!--            <a class="btn" href="/index.php/table">Back</a>-->
            
        </div>
    </div>

    <?php ActiveForm::end(); ?>
    
    
    			
				
    </div> <!-- /container -->