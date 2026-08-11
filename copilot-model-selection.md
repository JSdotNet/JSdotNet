# Copilot Model Selection

Use these Azure Foundry model catalog and deployment entries for Copilot and plugin configuration. In the UI, the **Wire model** value must match the Azure Foundry deployment/model ID exactly.

Prefer Microsoft Foundry models while the Anthropic provider still injects the deprecated `temperature` parameter for Claude 5 requests. Claude 5 reasoning calls currently fail when that sampling parameter is sent.

## Azure Foundry catalog entries

| Foundry display name | Wire model | Max prompt tokens | Max output tokens | Intended use |
| --- | --- | ---: | ---: | --- |
| `gpt-5.4` | `gpt-5.4` | 922000 | 128000 | Default configured model |
| `gpt-5.5` | `gpt-5.5` | 922000 | 128000 | Premium fallback |
| `gpt-5.6-luna` | `gpt-5.6-luna` | 922000 | 128000 | Fast and cheaper routine work |
| `gpt-5.6-sol` | `gpt-5.6-sol` | 922000 | 128000 | Optional balanced alternative |
| `claude-sonnet-4-6` | `claude-sonnet-4-6` | 1000000 | 128000 | Conditional Claude fallback only when the Foundry catalog/provider accepts requests without deprecated `temperature` |
| `claude-sonnet-4-5` | `claude-sonnet-4-5` | 200000 | 64000 | Conditional Claude fallback only when the Foundry catalog/provider accepts requests without deprecated `temperature` |
| `claude-haiku-4-5` | `claude-haiku-4-5` | 200000 | 64000 | Conditional Claude fallback only when the Foundry catalog/provider accepts requests without deprecated `temperature` |

## Claude 5 policy

Avoid Claude 5 Azure Foundry catalog entries until the provider stops sending `temperature`:

- `claude-opus-5`
- `claude-sonnet-5`
- `claude-fable-5`

## Reasoning model parameter guardrails

Do not configure sampling or legacy completion parameters for reasoning models. In particular, omit:

- `temperature`
- `top_p`
- frequency, presence, or repetition penalties
- `logprobs`
- `logit_bias`
- `max_tokens`

Use the model's supported output-token field instead of `max_tokens` when a token limit is required.
