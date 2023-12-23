import React, {useState} from 'react';
import classes from "./BuyForm.module.css";
import MyInput from "../input/MyInput";
import MyButton from "../button/MyButton";
import {useParams} from "react-router-dom";

const BuyForm = ({buyFunction, title, price}) => {
    let params = useParams()
    const [card, setCard] = useState({number:'', month:'', year: '', cvc:''})
    const [errorMessage, setMessage] = useState('')
    //const [titleProduct, setTitle] = useState(title)
    //const [priceProduct, setPrice] = useState(price)


    const buy = (e) => {
        e.preventDefault()
        if (!card.number ||
            !card.month ||
            !card.year ||
            !card.cvc) {
            setMessage("Необходимо заполнить все поля")
            return
        }

        const data = {
            ...card
        }
        try {
            buyFunction(card)
            setCard({number:'', month:'', year: '', cvc:''})
            setMessage('')
        } catch (e) {
            setMessage(e)
        }
    }

    return (
        <div className={classes.BuyFormTable}>
            <div className={classes.BuyFormColumn}>
                <div className={classes.BuyFormInputForm}>
                    <div className={classes.BuyFormTitleText}>{title}</div>
                    {errorMessage
                        ?
                        <div className={classes.BuyForm_Access}>
                            <div className={classes.BuyForm_Access_Text}>{errorMessage}</div>
                        </div>
                        :
                        null
                    }

                    <div className={classes.BuyFormRow}>
                        <MyInput
                            id="number"
                            value={card.number}
                            onChange={e => setCard({...card, number: e.target.value})}
                            type="text"
                            placeholder="Номер карты"
                        />
                    </div>
                    <div className={classes.BuyFormRow}>
                        <MyInput
                            id="MM"
                            value={card.month}
                            onChange={e => setCard({...card, month: e.target.value})}
                            type="text"
                            placeholder="MM"
                        />
                        <MyInput
                            id="YYYY"
                            value={card.year}
                            onChange={e => setCard({...card, year: e.target.value})}
                            type="text"
                            placeholder="YYYY"
                        />
                        <MyInput
                            id="CVC"
                            value={card.cvc}
                            onChange={e => setCard({...card, cvc: e.target.value})}
                            type="password"
                            placeholder="CVC"
                        />
                    </div>
                    <div className={classes.BuyFormRow}>
                        <div className={classes.BuyFormPrice}>К оплате: {price}</div>
                    </div>
                    <div className={classes.BuyFormRow}>
                        <MyButton onClick={buy}>
                            Оплатить
                        </MyButton>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default BuyForm;