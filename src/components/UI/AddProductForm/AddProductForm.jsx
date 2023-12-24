import React, {useContext, useState} from 'react';
import classes from "./AddProductForm.module.css";
import MyInput from "../input/MyInput";
import {useFetching} from "../../../hooks/useFetching";
import MyButton from "../button/MyButton";
import BackService from "../../../API/BackService";
import {AuthContext} from "../../../context";

const AddProductForm = ({...props}) => {
    const {token} = useContext(AuthContext)
    const [productData, setProductData] = useState(
        {title:'', description:'', image:'', category:'', nation:'', price: ''})
    const [startProcess, setStartProcess] = useState(false)

    const [addNewProduct, isLoading, error] = useFetching(async (data) => {
        const response = await BackService.createProduct({...data, token:token.token})
    })

    function addProduct() {
        if (!productData.title ||
            !productData.image ||
            !productData.category ||
            !productData.nation ||
            !productData.price) {
            return null;
        }
        setStartProcess(true)
        addNewProduct(productData)
    }

    return (
        <div className={classes.AddProductForm}>
            {!startProcess
                ?
                <div className={classes.AddProductForm_InfoContainer}>
                    <div className={classes.AddProductForm_InfoContainer_Wrapper}>
                        <MyInput
                            id="title"
                            value={productData.title}
                            onChange={e => setProductData({...productData, title: e.target.value})}
                            type="text"
                            placeholder="Название"
                        />
                        <MyInput
                            id="description"
                            value={productData.description}
                            onChange={e => setProductData({...productData, description: e.target.value})}
                            type="text"
                            placeholder="Описание"
                        />
                        <MyInput
                            id="category"
                            value={productData.category}
                            onChange={e => setProductData({...productData, category: e.target.value})}
                            type="text"
                            placeholder="Категория"
                        />
                        <MyInput
                            id="nation"
                            value={productData.nation}
                            onChange={e => setProductData({...productData, nation: e.target.value})}
                            type="text"
                            placeholder="Нация"
                        />
                        <MyInput
                            id="image"
                            value={productData.image}
                            onChange={e => setProductData({...productData, image: e.target.value})}
                            type="text"
                            placeholder="Ссылка на изображение"
                        />
                        <MyInput
                            id="price"
                            value={productData.price}
                            onChange={e => setProductData({...productData, price: e.target.value})}
                            type="text"
                            placeholder="Цена"
                        />
                        <div style={{width: "300px"}}>
                            <MyButton onClick={addProduct}>
                                Добавить товар
                            </MyButton>
                        </div>
                    </div>
                </div>
                :
                null
            }

            {startProcess && isLoading
                ?
                <div className={classes.AddProductForm_Title}>
                    <div className={classes.AddProductForm_Title_Text}>
                        Идёт добавление товара...
                    </div>
                </div>
                :
                null
            }

            {startProcess && !isLoading && !error
                ?
                <div className={classes.AddProductForm_Title}>
                    <div className={classes.AddProductForm_Title_Text}>
                        Товар добавлен успешно
                    </div>
                    <div style={{width: "300px"}}>
                        <MyButton onClick={() => {setProductData({title:'', description:'', image:'', category:'', nation:'', price: ''});
                                                        setStartProcess(false)}}>
                            Ок
                        </MyButton>
                    </div>
                </div>
                :
                null
            }

            {startProcess && !isLoading && error
                ?
                <div className={classes.AddProductForm_Title}>
                    <div className={classes.AddProductForm_Title_Text}>
                        Очередная имба НЕ добавлена
                    </div>
                    <div style={{width: "300px"}}>
                        <MyButton onClick={() => {setProductData({title:'', description:'', image:'', category:'', nation:'', price: ''});
                            setStartProcess(false)}}>
                            Не Ок
                        </MyButton>
                    </div>
                </div>
                :
                null
            }
        </div>
    );
};

export default AddProductForm;