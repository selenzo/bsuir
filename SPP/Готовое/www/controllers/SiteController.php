<?php

namespace app\controllers;

use Yii;
use yii\filters\AccessControl;
use yii\web\Controller;
use yii\filters\VerbFilter;
use app\models\User;
use app\models\LoginForm;
use app\models\Customers;

class SiteController extends Controller
{

    public function actions()
    {
        return [
            'error' => [
                'class' => 'yii\web\ErrorAction',
            ],
            'captcha' => [
                'class' => 'yii\captcha\CaptchaAction',
                'fixedVerifyCode' => YII_ENV_TEST ? 'testme' : null,
            ],
        ];
    }

    public function actionTable()
    {
        $customers = Customers::find()->All();

        return $this->render('table', [
                'rows' => $customers,
            ]);
    }

    public function actionLogin()
    {
        if (!\Yii::$app->user->isGuest) {
            return $this->goHome();
        }

        $model = new LoginForm();
        if ($model->load(Yii::$app->request->post()) && $model->login()) {
            return $this->goBack();
        } else {
            return $this->render('login', [
                'model' => $model,
            ]);
        }
    }

    public function actionLogout()
    {
        Yii::$app->user->logout();

        return $this->goHome();
    }


    public function actionIndex()
    {
        $users = User::findOne(5);
        return $this->render('index', [
                'us' => $users,
    ]);
    }

}





/*
$user = new User();
        $user->Username = 'admin';

        $salt = openssl_random_pseudo_bytes(22);
        $salt = '$2a$%13$' . strtr(base64_encode($salt), array('_' => '.', '~' => '/'));


        $user->Password = crypt('admin', $salt);

        $salt = '$2a$%13$' . strtr(base64_encode(openssl_random_pseudo_bytes(22)), array('_' => '.', '~' => '/'));

        $user->AuthKey = '$2a$%13$' . strtr(base64_encode(openssl_random_pseudo_bytes(22)), array('_' => '.', '~' => '/'));;
        $user->AccessToken ='$2a$%13$' . strtr(base64_encode(openssl_random_pseudo_bytes(22)), array('_' => '.', '~' => '/'));;
        $user->save();
*/
