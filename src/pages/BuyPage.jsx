import React, {useEffect, useState} from 'react';
import {useNavigate, useParams} from "react-router-dom";
import CreateForm from "../components/UI/CreateForm/CreateForm";
import BuyForm from "../components/UI/BuyForm/BuyForm";
import {useFetching} from "../hooks/useFetching";
import classes from "../../src/components/UI/BuyForm/BuyForm.module.css";
import MyButton from "../components/UI/button/MyButton";
import BackService from "../API/BackService";

const BuyPage = () => {
    const params = useParams()
    let navigate = useNavigate()

    const [startBuy, setStart] = useState( false)
    const [buyProduct, isProcessBuy, error] = useFetching(async (cardData) => {

    })

    function buy(card) {
        setStart(true)
        buyProduct(card)
    }

    return (
        <div style={{
            display: "flex",
            width: "100%",
            flexDirection: 'column',
            alignItems: 'center',
        }}>
            {!startBuy
                ?
                <BuyForm
                    title="Набор 'Нагиб до следующего патча'"
                    price="Одна почка"
                    buyFunction={buy}
                />
                :
                null
            }

            {startBuy && isProcessBuy
                ?
                <div className={classes.BuyFormTitleText}>
                    Подождите окончание операции
                </div>
                :
                null
            }
            {startBuy && !isProcessBuy && !error
                ?
                <div className={classes.BuyFormTable}>
                    <div className={classes.BuyFormColumn}>
                        <div className={classes.BuyFormRow}>
                            <div className={classes.BuyFormTitle}>
                                <div className={classes.BuyFormTitleText}>
                                    Покупка совершена успешно
                                </div>
                            </div>
                        </div>
                        <div className={classes.BuyFormRow}>
                            <MyButton onClick={() => {navigate('/')}}>
                                Вернуться на главную страницу
                            </MyButton>
                        </div>
                    </div>
                </div>
                :
                null
            }

            {startBuy && !isProcessBuy && error
                ?
                <div className={classes.BuyFormTable}>
                    <div className={classes.BuyFormColumn}>
                        <div className={classes.BuyFormRow}>
                            <div className={classes.BuyFormTitle}>
                                <div className={classes.BuyFormTitleText}>
                                    Произошла ошибка
                                </div>
                            </div>
                        </div>
                        <div className={classes.BuyFormRow}>
                            <MyButton onClick={() => {navigate('/')}}>
                                Вернуться на главную страницу
                            </MyButton>
                        </div>
                    </div>
                </div>
                :
                null
            }
        </div>
    );
};

export default BuyPage;