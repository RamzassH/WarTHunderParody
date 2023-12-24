import React, {useContext, useEffect, useState} from 'react';
import {useNavigate, useParams} from "react-router-dom";
import CreateForm from "../components/UI/CreateForm/CreateForm";
import BuyForm from "../components/UI/BuyForm/BuyForm";
import {useFetching} from "../hooks/useFetching";
import classes from "../../src/components/UI/BuyForm/BuyForm.module.css";
import MyButton from "../components/UI/button/MyButton";
import BackService from "../API/BackService";
import {AuthContext} from "../context";

const BuyPage = () => {
    const {token} = useContext(AuthContext);
    const params = useParams()
    let navigate = useNavigate()

    const [startBuy, setStart] = useState(false)
    const [prodInfo, setProdInfo] = useState({title: '', price: ''})
    const [buyProduct, isProcessBuy, error] = useFetching(async (cardData) => {
        const response = await BackService.purchase(params.id, cardData, token.token);
    })
    const [productInfo, isGetInfo, errorNotInfo] = useFetching(async () => {
        const response = await BackService.getProduct(params.id);
        setProdInfo({title: response.data.name, price: response.data.price})
    })
    useEffect(() => {
        productInfo()
    }, []);

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
                    title={prodInfo.title}
                    price={prodInfo.price}
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
                            <MyButton onClick={() => {
                                navigate('/')
                            }}>
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
                            <MyButton onClick={() => {
                                navigate('/')
                            }}>
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