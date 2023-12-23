import React, {useState} from 'react';
import classes from "./AddProductForm.module.css";
import MyInput from "../input/MyInput";

const AddProductForm = ({...props}) => {
    const [productData, setProductData] = useState(
        {title:'', description:'', image:'', category:'', nation:'', price: ''})

    return (
        <div className={classes.AddProductForm}>
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
                </div>
            </div>
        </div>
    );
};

export default AddProductForm;