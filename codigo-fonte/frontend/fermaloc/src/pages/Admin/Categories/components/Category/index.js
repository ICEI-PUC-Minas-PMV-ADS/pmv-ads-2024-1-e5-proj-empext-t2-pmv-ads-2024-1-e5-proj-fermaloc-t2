import React, { useState } from "react";
import { FaEdit } from "react-icons/fa";
import styles from "./styles.module.css";
import EditCategoryForm from "../EditCategoryForm";

export default function Category({ category }) {
  const [viewEditForm, setViewEditForm] = useState(false);

  return (
    !viewEditForm ? (
      <div className={styles.container}>
        <p>{category.name}</p>
        <FaEdit onClick={() => setViewEditForm(true)} />
      </div>
    ) : (
      <EditCategoryForm category={category} setViewEditForm={setViewEditForm}/>
    )
  );
}
