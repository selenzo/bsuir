<?php

namespace app\controllers;

use Yii;
use yii\filters\AccessControl;
use yii\web\Controller;
use yii\filters\VerbFilter;
use app\models\User;
use app\models\LoginForm;
use app\models\Customers;
use yii\helpers\VarDumper;

class TableController extends Controller
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
    
    public function actionIndex()
    {
        $customers = Customers::find()->All();
        
        return $this->render('table', [
                'rows' => $customers,
            ]);
    }
    
    public function actionRead()
    {
//        VarDumper::dump();
        $customers = Customers::findOne($_GET['id']);
        
        return $this->render('read', [
                'data' => $customers,
            ]);
    }
    
    
    public function actionDelete()
    {
        
        $idd = $_GET['id'];
        
        if(Yii::$app->request->isPost)
        {
            $mod = new Customers();
            $mod->delete();
            $this->redirect( array('/table/index') );
        }
        else
        {
            return $this->render('delete', [
                'id' => $idd,
            ]);
//            throw new CHttpException(400, 'Invalid request. Please do not repeat this request again.');
        }
        
    }
    
    public function actionUpdate()
    {
        
        $mod = Customers::findOne($_GET['id']);
        
        if(Yii::$app->request->isPost)
        {
            $mod->load(Yii::$app->request->post());
//            VarDumper::dump($mod);
//            $mod = new Customers();
            $mod->CUpdate();
            $this->redirect( array('/table/index') );
        }
        else
        {
            return $this->render('update', [
                'data' => $mod,
            ]);
//            throw new CHttpException(400, 'Invalid request. Please do not repeat this request again.');
        }
        
        
    }
    
    
    public function actionCreate()
    {
        $mod = new Customers();

        if ($mod->load(Yii::$app->request->post()) && $mod->create()) {
      
//             VarDumper::dump($_POST["Cancel"]);

//            return $this->goBack();
            $this->redirect( array('/table/index') );
        }else {
            return $this->render('create', [
                'model' => $mod,
            ]);
        }
        
    }
    
    
    
}

