<?php

namespace app\models;

use Yii;
use yii\db\ActiveRecord;
use yii\helpers\VarDumper;


class Customers extends ActiveRecord
{
    public function rules()
    {
        return [
            // username and password are both required
            [['name', 'email', 'mobile'], 'required'],
            // rememberMe must be a boolean value
        ];
    }


    public static function model($className=__CLASS__)
    {
        return parent::model($className);
    }

    public static function tableName()
    {
        return 'Customers';
    }


    public function Create()
    {
        $cst = new Customers();
        $cst->name = $this->name;
        $cst->email = $this->email;
        $cst->mobile = $this->mobile;

        return $cst->save();
    }


    public function CUpdate()
    {
//        $cst = new Customers();

        $cst = Customers::findOne($this->id);
        $cst = $cst->findOne($this->id);
//        VarDumper::dump($cst);
        $cst->name = $this->name;
        $cst->email = $this->email;
        $cst->mobile = $this->mobile;

        return $cst->save();
    }

    public function delete()
    {
         $idd = $_POST['id'];

        Customers::deleteAll('id = :id', [':id' => $idd]);

//       $cst = Customers()->findOne($idd);
//        VarDumper::dump($cst);
//        VarDumper::dump($idd);
//        $cst->delete();
//        $cst->name = $this->name;
//        $cst->email = $this->email;
//        $cst->mobile = $this->mobile;
//
//        return $cst->save();
    }

}

?>
