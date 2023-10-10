import * as React from 'react';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';

export default function botao(props){
    return(
        <Button variant="contained"
        key={props.id}
              nome={props.nome}
              action={props.action}
              onChange={props.onChange}>
            {props.nome}
        </Button>
    )
}