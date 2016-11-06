<?php
use yii\helpers\Html;
use yii\helpers\VarDumper;
use yii\bootstrap\ActiveForm;





/* @var $this yii\web\View */
/* @var $form yii\bootstrap\ActiveForm */
/* @var $model app\models\LoginForm */

$this->title = 'Read';


//$this->params['breadcrumbs'][] = array( 'homeLink'=>array('/admin'));
$this->params['breadcrumbs'][] = $this->title;

?>


    <div class="container">

        <div class="span10 offset1">
            <div class="row">
                <h3>Read a Customer</h3>
            </div>

           <table class="table table-striped table-bordered">
		              <thead>
		                <tr>
		                  <th>Name</th>
		                  <th>Email Address</th>
		                  <th>Mobile Number</th>
		                </tr>
		              </thead>
		              <tbody>
		              <?php
//VarDumper::dump($rows);
//                         VarDumper($rows);

						   		echo '<tr>';
							   	echo '<td>'. $data['name'] . '</td>';
							   	echo '<td>'. $data['email'] . '</td>';
							   	echo '<td>'. $data['mobile'] . '</td>';

							   	echo '</tr>';

					  ?>
				      </tbody>
	            </table>


           <div class="form-actions">
                    <?= Html::submitButton('Cancel', ['class' => 'btn', 'name' => 'cancel-button', 'onClick' => 'javascript:history.back()']) ?>

                </div>




            </div>
        </div>

    </div>
    <!-- /container -->
