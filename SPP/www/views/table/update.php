<?php
use yii\helpers\Html;
use yii\helpers\VarDumper;
use yii\bootstrap\ActiveForm;

/* @var $this yii\web\View */
/* @var $form yii\bootstrap\ActiveForm */
/* @var $model app\models\LoginForm */

$this->title = 'Update';
$this->params['breadcrumbs'][] = $this->title;
?>


    <div class="container">
        <div class="row">
                <h3>Update a Customer</h3>
            </div>
            <br>
        
        
         <?php $form = ActiveForm::begin([
        'id' => 'update-form',
        'options' => ['class' => 'form-horizontal'],
        'fieldConfig' => [
            'template' => "{label}\n<div class=\"col-lg-3\">{input}</div>\n<div class=\"col-lg-8\">{error}</div>",
            'labelOptions' => ['class' => 'col-lg-1 control-label'],
        ],
    ]); ?>

    <?= $form->field($data, 'name')    ?>

    <?= $form->field($data, 'email')?>
    
    <?= $form->field($data, 'mobile')?>

    <div class="form-group">
        <div class="col-lg-offset-1 col-lg-11">
            <?= Html::submitButton('Update', ['class' => 'btn btn-success', 'name' => 'update-button']) ?>
             <?= Html::submitButton('Cancel', ['class' => 'btn', 'name' => 'cancel-button', 'onClick' => 'javascript:history.back()']) ?>
            
            
<!--            <a class="btn" href="/index.php/table">Back</a>-->
            
        </div>
    </div>

    <?php ActiveForm::end(); ?>
    
        

       

    </div>
    <!-- /container -->