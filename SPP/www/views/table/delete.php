<?php
use yii\helpers\Html;
use yii\helpers\VarDumper;
use yii\bootstrap\ActiveForm;


/* @var $this yii\web\View */
/* @var $form yii\bootstrap\ActiveForm */
/* @var $model app\models\LoginForm */

$this->title = 'Delete';
$this->params['breadcrumbs'][] = $this->title;
?>

<div class="container">
   
   
   
   <?php $form = ActiveForm::begin([
        'id' => 'delete-form',
        'options' => ['class' => 'form-horizontal'],
        'fieldConfig' => [
            'template' => "{label}\n<div class=\"col-lg-3\">{input}</div>\n<div class=\"col-lg-8\">{error}</div>",
            'labelOptions' => ['class' => 'col-lg-1 control-label'],
        ],
    ]); ?>
    
    <div class="row">
		    			<h3>Delete a Customer</h3>
		    		</div>
<p class="alert alert-error">Are you sure to delete ?</p>
   <input type="hidden" name="id" value="<?php echo $id;?>"/>
					      
    <div class="form-group">
        <div class="col-lg-offset-1 col-lg-11">
           <?= Html::submitButton('Delete', ['class' => 'btn btn-danger', 'name' => 'delete-button']) ?>
            <?= Html::submitButton('Cancel', ['class' => 'btn', 'name' => 'cancel-button', 'onClick' => 'javascript:history.back()']) ?>
<!--            <a class="btn" href="/index.php/table">Back</a>-->
            
        </div>
    </div>

    <?php ActiveForm::end(); ?>
   
    
    			<div class="span10 offset1">
    				
		    		
	    			<form class="form-horizontal" action="delete" method="post">
	    			  <input type="hidden" name="id" value="<?php echo $id;?>"/>
					  
					  <div class="form-actions">
						   
            
						</div>
					</form>
				</div>
				
    </div> <!-- /container , 'onClick' => 'javascript:history.back()'-->