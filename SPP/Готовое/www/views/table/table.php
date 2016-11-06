<?php
use yii\helpers\Html;
use yii\helpers\VarDumper;

/* @var $this yii\web\View */
/* @var $form yii\bootstrap\ActiveForm */
/* @var $model app\models\LoginForm */

$this->title = 'Table';
$this->params['breadcrumbs'][] =  $this->title;
?>

<div class="container">
    		<div class="row">
    			<h3>CRUD Grid</h3>
    		</div>
			<div class="row">
				<p>
					<a href="create" class="btn btn-success">Create</a>
				</p>

				<table class="table table-striped table-bordered">
		              <thead>
		                <tr>
		                  <th>Name</th>
		                  <th>Email Address</th>
		                  <th>Mobile Number</th>
		                  <th>Action</th>
		                </tr>
		              </thead>
		              <tbody>
		              <?php

//VarDumper::dump($rows);
//                         VarDumper($rows);
	 				   foreach ($rows as $row) {
						   		echo '<tr>';
							   	echo '<td>'. $row['name'] . '</td>';
							   	echo '<td>'. $row['email'] . '</td>';
							   	echo '<td>'. $row['mobile'] . '</td>';
							   	echo '<td width=250>';
							   	echo '<a class="btn btn-info" href="read?id='.$row['id'].'">Read</a>';
							   	echo '&nbsp;';
                           if(Yii::$app->user->isGuest)
                            {
                               echo '<a class="btn btn-success disabled" href="update?id='.$row['id'].'">Update</a>';
                           }
                           else
                               {
                               echo '<a class="btn btn-success" href="update?id='.$row['id'].'">Update</a>';
                           }

							   	echo '&nbsp;';

                           if(Yii::$app->user->isGuest)
                            {
                               echo '<a class="btn btn-danger disabled" href="delete?id='.$row['id'].'">Delete</a>';
                           }
                           else
                               {
                               echo '<a class="btn btn-danger" href="delete?id='.$row['id'].'">Delete</a>';
                           }



							   	echo '</td>';
							   	echo '</tr>';
					   }
					  ?>
				      </tbody>
	            </table>
    	</div>
    </div> <!-- /container -->
