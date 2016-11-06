<?php

namespace app\models;

use Yii;
use yii\db\ActiveRecord;
use yii\helpers\VarDumper;


class User extends ActiveRecord implements \yii\web\IdentityInterface
{


    public static function findIdentity($id)
    {
        return static::findOne($id);
    }

    /**
     * @inheritdoc
     */
    public static function findIdentityByAccessToken($token, $type = null)
    {

        return static::findOne(['AccessToken' => $token]);
    }

    /**
     * @inheritdoc
     */
    public function getId()
    {
        return $this->Id;
    }

    /**
     * @inheritdoc
     */
    public function getAuthKey()
    {
        return $this->AuthKey;
    }

    /**
     * @inheritdoc
     */
    public function validateAuthKey($authKey)
    {
         return $this->getAuthKey() === $authKey;
    }



    public static function tableName()
    {
        return 'Users';
    }

    public static function test()
    {
        $users = User::find();
        return $users[0]["Id"];
    }

    public static function findByUsername($username)
    {
        $users = User::find()->All();

        foreach ($users as $user) {
            if (strcasecmp($user->Username, $username) === 0) {
                return new static($user);
            }
        }

        return null;
    }



}

?>
